using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] string taskName = "Untitled Task";
    [SerializeField] int taskReward = 20;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    public TaskScriptableObject taskData;
}
