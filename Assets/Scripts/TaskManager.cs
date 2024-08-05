using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour, IDataPersistence
{
    public GameObject taskItemPrefab;
    public Transform parentTransform;
    private List<TaskScriptableObject> taskScriptableObjects;

    private void Start() 
    {
        // subscribe to events
        GameEventsManager.instance.createNewTask += CreateNewTask;
        RenderTasks();
    }

    public void LoadData(GameData data)
    {
        this.taskScriptableObjects = data.taskScriptableObjects;
        RenderTasks();
    }

    public void SaveData(ref GameData data)
    {
        data.taskScriptableObjects = this.taskScriptableObjects;
    }

    private void RenderTasks()
    {
        foreach (TaskScriptableObject obj in taskScriptableObjects)
        {
            RenderTaskItem(obj);
        }
    }

    private void RenderTaskItem(TaskScriptableObject obj)
    {
        GameObject currentTask = Instantiate(taskItemPrefab);
        currentTask.transform.SetParent(parentTransform);
        Task taskScript = currentTask.GetComponent<Task>();
        taskScript.taskObject = obj;
    }

    private void CreateNewTask(string name, int reward)
    {
        Debug.Log("created new task");
        TaskScriptableObject newTaskObject = ScriptableObject.CreateInstance<TaskScriptableObject>();
        newTaskObject.taskName = name;
        newTaskObject.taskReward = reward;
        newTaskObject.id = System.Guid.NewGuid().ToString();
        taskScriptableObjects.Add(newTaskObject);
        RenderTasks();
    }

    private string GenerateGuid(string id)
    {
        if (id == null)
            return System.Guid.NewGuid().ToString();
        return id;
    }

}
