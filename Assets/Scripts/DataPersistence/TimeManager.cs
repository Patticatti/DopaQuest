using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour, IDataPersistence
{
    private List<string> loginDates = new List<string>();
    // Start is called before the first frame update
    private void Start()
    {
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
    }

    public void LoadData(GameData data)
    {
        Debug.Log("loaded time data" + data.loginDates);
        this.loginDates = data.loginDates;
        DateTime currentDate = DateTime.Now;
        loginDates.Add(currentDate.ToString());
        Debug.Log("saved time data" + currentDate.ToString());
    }

    public void SaveData(ref GameData data)
    {
        data.loginDates = this.loginDates;
    }
}
