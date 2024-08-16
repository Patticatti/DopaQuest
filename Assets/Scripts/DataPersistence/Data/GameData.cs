using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]

public class GameData 
{
    public int gemCount;
    public List<TaskObject> taskObjects;
    public List<DateTime> loginDates;

    public GameData(){
        this.gemCount = 0;
        this.taskObjects = new List<TaskObject>();
        this.loginDates = new List<DateTime>();
    }
}
