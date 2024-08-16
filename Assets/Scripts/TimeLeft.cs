using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimeLeft : MonoBehaviour
{
    private TextMeshProUGUI timeLeftText; // Reference to a UI Text component to display the time left
    private TimeSpan timeLeft;

    void Start()
    {
        timeLeftText = this.GetComponent<TextMeshProUGUI>();
        InvokeRepeating("UpdateTimeLeft", 0f, 1f); // Updates every 1 second
    }

    void UpdateTimeLeft()
    {
        // Get the current time
        DateTime currentTime = DateTime.Now;

        // Calculate the time left until midnight
        DateTime midnight = currentTime.Date.AddDays(1); // Midnight is the start of the next day
        timeLeft = midnight - currentTime;

        // Update the UI text to show the time left in hours and minutes
        timeLeftText.text = string.Format("Time left: {0}h {1}m", timeLeft.Hours, timeLeft.Minutes);
    }
}
