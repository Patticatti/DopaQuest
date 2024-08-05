using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;
    }

    public event Action<int> onGemsCollected;
    public void GemsCollected(int gemsCollected) 
    {
        if (onGemsCollected != null) 
        {
            onGemsCollected(gemsCollected);
        }
    }

    public event Action<string, int> createNewTask;
    public void CreateNewTask(string taskName, int taskReward) 
    {
        if (createNewTask != null) 
        {
            createNewTask(taskName, taskReward);
        }
    }

    public event Action<string> deleteTask;
    public void DeleteTask(string taskID) 
    {
        if (deleteTask != null) 
        {
            deleteTask(taskID);
        }
    }
}