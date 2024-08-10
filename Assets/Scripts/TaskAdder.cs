using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskAdder : MonoBehaviour
{
    public string taskName;
    [SerializeField] private float mult = 1;
    public int difficulty = 1;
    public TextMeshProUGUI inputText;
    public ToggleGroup toggleGroup;

    public void SetDifficulty(int mode)
    {
        this.difficulty = mode;
    }

    public void CreateTask()
    {
        int reward = (10 * difficulty);
        taskName = inputText.text;  
        GameEventsManager.instance.CreateNewTask(taskName, reward);
        //reset everything
        this.difficulty = 1;
        inputText.text = "";
        this.taskName="";
    }
}
