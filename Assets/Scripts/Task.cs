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

    [SerializeField] TextMeshProUGUI taskRewardText;
    public Transform parentTransform;   // The parent transform for the instantiated gems
    public Toggle toggle;               // The UI Toggle component
    public int gemCount = 15;           // Number of gems to instantiate
    public float spawnInterval = 0.1f; 

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
            StartCoroutine(SpawnGems());
            // toggle.interactable = false; // Disable the toggle
        }
    }

    private IEnumerator SpawnGems()
    {
        for (int i = 0; i < gemCount; i++)
        {
            GameObject newGem = Instantiate(gemPrefab, parentTransform);
            newGem.transform.SetParent(parentTransform);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
