using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour, IDataPersistence
{
    private List<string> loginDates = new List<string>();
    private int consecutiveCount = 1;
    [SerializeField] private TextMeshProUGUI streakCountText;

    public void LoadData(GameData data)
    {
        Debug.Log("loaded time data" + data.loginDates);
        this.loginDates = data.loginDates;

        DateTime currentDate = DateTime.Now;
        loginDates.Add(currentDate.ToString());

        consecutiveCount = CountConsecutiveLoginDays();
        streakCountText.text = "" + consecutiveCount;
        Debug.Log("Consecutive login days: " + consecutiveCount);
    }

    public void SaveData(ref GameData data)
    {
        data.loginDates = this.loginDates;
    }

    private int CountConsecutiveLoginDays()
    {
        List<DateTime> dateTimes = new List<DateTime>();
        foreach (string dateString in loginDates)
        {
            if (DateTime.TryParse(dateString, out DateTime dateTime))
            {
                dateTimes.Add(dateTime.Date); // Store only the date part
            }
        }
        dateTimes.Sort((a, b) => b.CompareTo(a));

        DateTime previousDate = DateTime.Now.Date;

        foreach (DateTime loginDate in dateTimes)
        {
            // If the login date is the same as the previous date, skip it (same day login)
            if (loginDate == previousDate)
            {
                continue;
            }

            // Check if the login date is exactly 1 day before the previous date
            if (loginDate == previousDate.AddDays(-1))
            {
                consecutiveCount++;
                previousDate = loginDate; // Move to the next day to check for consecutiveness
            }
            else
            {
                // Break if the dates are not consecutive
                break;
            }
        }

        return consecutiveCount;
    }
}
