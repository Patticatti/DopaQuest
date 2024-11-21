using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour, IDataPersistence
{
    public GameObject taskItemPrefab;
    public Transform parentTransform;
    public GameObject addPanel;
    private List<TaskObject> taskObjects = new List<TaskObject>();
    private Dictionary<TaskObject, GameObject> taskObjectToGameObjectMap = new Dictionary<TaskObject, GameObject>();

    private void Start() 
    {
        // subscribe to events
        GameEventsManager.instance.createNewTask += CreateNewTask;
        RenderTasks();
    }

    public void LoadData(GameData data)
    {
        this.taskObjects = data.taskObjects;
        RenderTasks();
    }

    public void SaveData(ref GameData data)
    {
        data.taskObjects = this.taskObjects;
    }

    public void SwitchMode(int mode)
    {
        switch (mode)
        {
            case 0:
                addPanel.SetActive(false);
                break;
            case 1:
                addPanel.SetActive(true);
                break;
        }
    }

    private void RenderTasks()
    {
        foreach (TaskObject obj in taskObjects)
        {
            RenderTaskItem(obj);
        }
    }

    private void ResetDailyTasks() 
    {
        foreach (TaskObject obj in taskObjects)
        {
            obj.isComplete = false;
        }
    }

    private void RenderTaskItem(TaskObject obj)
    {
        GameObject currentTask = Instantiate(taskItemPrefab);
        currentTask.transform.SetParent(parentTransform); 
        Task taskScript = currentTask.GetComponent<Task>();
        taskScript.taskObject = obj;
        // if (TimeManager.instance.GetLoggedInToday() == false)
        // {
        //     if (obj.isComplete == true)
        //     {
        //         obj.isComplete = false; //if first login of day, set completed to false
        //         obj.streak += 1;
        //     }
        //     else {
        //         obj.streak = 0;
        //     }
        // }
        if (!obj.isComplete){
            currentTask.transform.SetAsFirstSibling();  
        }
        taskObjectToGameObjectMap[obj] = currentTask;
    }

    private void CreateNewTask(string name, int reward)
    {
        Debug.Log("created new task");
        TaskObject currentTask = new TaskObject(System.Guid.NewGuid().ToString(), name, reward, GetCurrentDateTime());
        taskObjects.Add(currentTask);
        RenderTaskItem(currentTask);
    }

    private void DeleteTaskObject(TaskObject taskObject)
    {
        if (taskObjectToGameObjectMap.TryGetValue(taskObject, out GameObject taskGameObject))
        {
            // Remove the TaskObject from the list
            taskObjects.Remove(taskObject);

            // Destroy the GameObject
            Destroy(taskGameObject);

            // Remove the mapping
            taskObjectToGameObjectMap.Remove(taskObject);
        }
    }

    private string GenerateGuid(string id)
    {
        if (id == null)
            return System.Guid.NewGuid().ToString();
        return id;
    }

    private string GetCurrentDateTime()
    {
        DateTime now = DateTime.Now;
        string format = "MM/dd/yyyy h:mm tt";
        return now.ToString(format);
    }

}
