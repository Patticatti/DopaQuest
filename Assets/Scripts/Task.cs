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
    public CrossOutText crossOutText;
    [SerializeField] TextMeshProUGUI taskRewardText;
    private float duration = 0.8f;

    private void Start()
    {
        // taskNameText = GetComponentInChildren<Text>()
        taskNameText.text = taskObject.taskName;
        taskRewardText.text = "" + taskObject.taskReward;
        taskReward = taskObject.taskReward;
        if (taskObject.isComplete)
        {
            toggle.isOn = true;
        }
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        PlayMenuClick();
        if (isOn)
        {
            GameEventsManager.instance.GemsCollected(taskObject.taskReward); // Add task reward
            taskObject.isComplete = true;
            StartFading();
            // toggle.interactable = false; // Disable the toggle
        }
        else{
            GameEventsManager.instance.GemsCollected(-taskObject.taskReward);
            taskObject.isComplete = false;
            gameObject.transform.SetAsFirstSibling();
        }
    }

    private void PlayMenuClick()
    {
        AudioManager.instance.PlaySound(menuClickSound);
    }

    private void StartFading()
    {
        StartCoroutine(FadeToAlpha(0.4f, duration));
    }

    private void SetFullOpacity()
    {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            Color startColor = image.color;
            image.color = new Color(startColor.r, startColor.g, startColor.b, 1);
        }
    }

    private IEnumerator FadeToAlpha(float targetAlpha, float duration)
    {
        Image image = GetComponent<Image>();
        if (image == null)
        {
            yield break;
        }

        Color startColor = image.color;
        float startAlpha = startColor.a;
        float time = 0;
        crossOutText.StartAnimateCrossOut();

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Ensure the final alpha is set to the target alpha
        image.color = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
        gameObject.transform.SetAsLastSibling();
    }
    
}
