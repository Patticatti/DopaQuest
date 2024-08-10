using System;

[Serializable]
public class TaskObject {
    public string id;
    public string taskName;
    public int taskReward;
    public bool isComplete;
    public string dateCreated;
    public string dateCompleted;

    public TaskObject (string id, string taskName, int taskReward, string dateCreated)
    {
        this.id = id;
        this.taskName = taskName;
        this.taskReward = taskReward;
        this.dateCreated = dateCreated;
    }
}
