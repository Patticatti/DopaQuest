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

    // Start is called before the first frame update
    public void SetTaskName()
    {
        if (String.IsNullOrEmpty(inputText.text))
        {
            taskName = "Untitled Task";
        }
        else
        {
          taskName = inputText.text;  
        }
        
    }

    public void SetDifficulty(int mode)
    {
        this.difficulty = mode;
    }

    public void CreateTask()
    {
        int reward = (10 * difficulty);
        GameEventsManager.instance.CreateNewTask(taskName, reward);
        //reset everything
        this.difficulty = 1;
        inputText.text = "";
        this.taskName="";
    }
}