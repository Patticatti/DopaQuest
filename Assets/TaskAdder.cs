using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskAdder : MonoBehaviour
{
    public string taskName;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTaskName(string inputValue)
    {
        taskName = inputValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
