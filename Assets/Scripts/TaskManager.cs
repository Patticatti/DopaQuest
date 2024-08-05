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

    private void RenderTaskItem(TaskObject obj)
    {
        GameObject currentTask = Instantiate(taskItemPrefab);
        currentTask.transform.SetParent(parentTransform); 
        if (!obj.isComplete){
            currentTask.transform.SetAsFirstSibling();  
        }
        Task taskScript = currentTask.GetComponent<Task>();
        taskScript.taskObject = obj;
        taskObjectToGameObjectMap[obj] = currentTask;
    }

    private void CreateNewTask(string name, int reward)
    {
        Debug.Log("created new task");
        TaskObject currentTask = new TaskObject(System.Guid.NewGuid().ToString(), name, reward);
        if (name == null)
        {
            currentTask.taskName = "Untitled Task";
        }
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

}
