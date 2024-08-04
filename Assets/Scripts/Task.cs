using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public TaskScriptableObject taskObject;
    public TextMeshProUGUI taskNameText;
    [SerializeField] TextMeshProUGUI taskRewardText;
    public Toggle toggle;
    public int taskReward;

    private void Start()
    {
        // taskNameText = GetComponentInChildren<Text>()
        taskNameText.text = taskObject.taskName;
        taskRewardText.text = "" + taskObject.taskReward;
        taskReward = taskObject.taskReward;
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            GameEventsManager.instance.GemsCollected(taskObject.taskReward); // Add task reward
            toggle.interactable = false; // Disable the toggle
        }
    }
}
