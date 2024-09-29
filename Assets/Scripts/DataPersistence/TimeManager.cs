using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour, IDataPersistence
{
    private List<DateTime> loginDates = new List<DateTime>();
    // Start is called before the first frame update
    private void Start()
    {
        DateTime currentTime = DateTime.Now;
        Debug.Log("added current time" + currentTime);
        // if (loginDates.Count > 0)
        // {
        //     DateTime lastDateTime = loginDates[loginDates.Count - 1];
        //     if (lastDateTime.Date == currentTime.Date)
        //     {
        //     Console.WriteLine("The last DateTime in the list is the same day as the current time.");
        //     }
        //     else
        //     {
        //     Console.WriteLine("The last DateTime in the list is NOT the same day as the current time.");
        //     }
        // }
        loginDates.Add(currentTime);
    }

    public void LoadData(GameData data)
    {
        Debug.Log("loaded time data");
        this.loginDates = data.loginDates;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("saved time data" + loginDates);
        data.loginDates = this.loginDates;
    }
}
