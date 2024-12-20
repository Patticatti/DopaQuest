using System;
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
    // public TextMeshProUGUI taskCreatedText;
    public int taskReward;
    public AudioClip menuClickSound;
    [SerializeField] TextMeshProUGUI taskRewardText;
    [SerializeField] TextMeshProUGUI taskStreakText;
    private float duration = 0.8f;
    private float crossOutDuration = 0.2f;
    private string originalText;

    private void Start()
    {
        if (taskObject.taskName == "" || taskObject.taskName == null)
            taskNameText.text = "Untitled Task";
        else
            taskNameText.text = taskObject.taskName;
        taskRewardText.text = "" + taskObject.taskReward;
        taskReward = taskObject.taskReward;
        SetTaskText();
        // taskCreatedText.text = "" + taskObject.dateCreated;
        originalText = taskNameText.text;
        if (taskObject.isComplete)
        {
            SetFaded();
            SetCrossedOut();
        }
    }

    public void CompleteTask(){
        if (!taskObject.isComplete)
        {
            SetCrossedOut();
        SetFaded();
        OnTaskCompletion(true);
        }else{
            OnTaskCompletion(false);
        }
        
    }

    private void SetTaskText()
    {
        taskStreakText.text = taskObject.streak + "/7";
    }

    //If is completed 
    private void OnTaskCompletion(bool isOn)
    {
        PlayMenuClick();
        if (isOn)
        {
            GameEventsManager.instance.GemsCollected(taskObject.taskReward); // Add task reward
            taskObject.isComplete = true;
            taskObject.streak += 1;
            SetTaskText();
            StartFading();
            // toggle.interactable = false; // Disable the toggle
        }
        else{
            GameEventsManager.instance.GemsCollected(-taskObject.taskReward);
            taskObject.isComplete = false;
            taskObject.streak -= 1;
            SetTaskText();
            gameObject.transform.SetAsFirstSibling();
            SetFullOpacity();
            SetOriginalText();
        }
    }

    private void PlayMenuClick()
    {
        AudioManager.instance.PlaySound(menuClickSound);
    }

    private void StartFading()
    {
        StartCoroutine(FadeToAlpha(0.3f, duration));
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

    private void SetFaded()
    {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            Color startColor = image.color;
            image.color = new Color(startColor.r, startColor.g, startColor.b, 0.4f);
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
        StartAnimateCrossOut();

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

    private void SetCrossedOut()
    {
        taskNameText.text = "<s>" + originalText + "</s>";
    }

    private void SetOriginalText()
    {
        taskNameText.text = originalText;
    }
    
    private void StartAnimateCrossOut()
    {
        StartCoroutine(AnimateCrossOut());
    }

    private IEnumerator AnimateCrossOut()
    {
        float time = 0;

        while (time < crossOutDuration)
        {
            time += Time.deltaTime;
            float t = time / crossOutDuration;
            int charCount = Mathf.FloorToInt(t * originalText.Length);
            string strikethroughText = "<s>" + originalText.Substring(0, charCount) + "</s>" + originalText.Substring(charCount);
            taskNameText.text = strikethroughText;
            yield return null;
        }

        // Ensure the entire text is crossed out
        SetCrossedOut();
    }
    
}
