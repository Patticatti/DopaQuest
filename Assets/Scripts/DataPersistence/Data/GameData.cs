using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int gemCount;
    public List<TaskObject> taskObjects;

    public GameData(){
        this.gemCount = 0;
        this.taskObjects = new List<TaskObject>();
    }
}
