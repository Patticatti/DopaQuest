using System;

[Serializable]
public class TaskObject {
    public string id;
    public string taskName;
    public int taskReward;
    public bool isComplete;

    public TaskObject (string id, string taskName, int taskReward)
    {
        this.id = id;
        this.taskName = taskName;
        this.taskReward = taskReward;
    }
}
