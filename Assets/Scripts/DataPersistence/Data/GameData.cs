using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int gemCount;
    public List<TaskScriptableObject> taskScriptableObjects;

    public GameData(){
        this.gemCount = 0;
        this.taskScriptableObjects = new List<TaskScriptableObject>();
    }
}
