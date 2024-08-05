using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TaskScriptableObject", order = 1)]
public class TaskScriptableObject : ScriptableObject
{
    public string id;
    public string taskName = "Untitled Task";
    public int taskReward = 10;
}
