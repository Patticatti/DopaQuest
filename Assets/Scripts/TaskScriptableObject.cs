using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TaskScriptableObject", order = 1)]
public class TaskScriptableObject : ScriptableObject
{
    public string taskName;
    public int taskReward = 10;
}
