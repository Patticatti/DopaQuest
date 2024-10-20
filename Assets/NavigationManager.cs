using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] private GameObject shopScreen;
    [SerializeField] private GameObject taskScreen;
    // [SerializeField] private GameObject dailyScreen;

    public void SetScene(int scene)
    {
        // Disable all scenes first
        shopScreen.SetActive(false);
        taskScreen.SetActive(false);
        // dailyScreen.SetActive(false);

        // Enable the selected scene based on the button pressed
        switch(scene)
        {
            case 0:
                shopScreen.SetActive(true);
                break;
            case 1:
                taskScreen.SetActive(true);
                break;
            // case 2:
            //     dailyScreen.SetActive(true);
            //     break;
            default:
                Debug.LogError("Invalid scene index");
                break;
        }
    }
}
