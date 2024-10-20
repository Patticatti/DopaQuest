using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventsManager : MonoBehaviour
{

    public static UIEventsManager instance {get; private set;}
    
    [SerializeField] private GameObject screenOverlay;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one UI Events Manager in the scene.");
        }
        instance = this;
    }

    private void Start(){
        GameEventsManager.instance.onGemsCollected += EnableScreenOverlay;
        screenOverlay.SetActive(false);
    }
    
    private void EnableScreenOverlay(int gemsCollected)
    {
        if (gemsCollected > 0)
            screenOverlay.SetActive(true);
    }
}
