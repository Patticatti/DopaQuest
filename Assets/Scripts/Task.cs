using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public TaskObject taskObject;
    public GameObject gemPrefab;  
    public TextMeshProUGUI taskNameText;
    public int taskReward;
    public Toggle toggle;
    public AudioClip menuClickSound;
    [SerializeField] TextMeshProUGUI taskRewardText;

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
            PlayMenuClick();
            // toggle.interactable = false; // Disable the toggle
        }
    }

    void PlayMenuClick()
    {
        AudioManager.instance.PlaySound(menuClickSound);
    }
}
