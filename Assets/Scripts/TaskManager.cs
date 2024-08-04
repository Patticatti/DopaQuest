using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject taskItemPrefab;
    public Transform content;
    [SerializeField] private List<TaskScriptableObject> taskScriptableObjects = new List<TaskScriptableObject>();

    private void Start() 
    {
        // subscribe to events
        GameEventsManager.instance.createNewTask += CreateNewTask;
    }

    public void LoadData(GameData data)
    {
        this.taskScriptableObjects = data.taskScriptableObjects;
    }

    public void SaveData(ref GameData data)
    {
        data.taskScriptableObjects = this.taskScriptableObjects;
    }

    private void RenderTask(string taskName, int taskReward)
    {
        GameObject currentTask = Instantiate(taskItemPrefab, content.position, Quaternion.identity, content.transform);
    }

    private void CreateNewTask(string taskName, int taskReward)
    {
        GameObject currentTask = Instantiate(taskItemPrefab, content.position, Quaternion.identity, content.transform);
    }

    private string GenerateGuid(string id)
    {
        if (id == null)
            return System.Guid.NewGuid().ToString();
        return id;
    }

}
