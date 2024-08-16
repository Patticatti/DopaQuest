using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCountText : MonoBehaviour, IDataPersistence
{
    private int gemCount = 0;
    private TextMeshProUGUI gemCountText;

    private void Awake(){
        gemCountText = this.GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    private void Start() 
    {
        // subscribe to events
        GameEventsManager.instance.onGemsCollected += OnGemsCollected;
        UpdateUI();
    }

    public void LoadData(GameData data)
    {
        this.gemCount = data.gemCount;
        UpdateUI();
    }

    public void SaveData(ref GameData data)
    {
        data.gemCount = this.gemCount;
    }

    private void OnGemsCollected(int gemsCollected)
    {
        gemCount += gemsCollected;
        UpdateUI();
    }

    private void UpdateUI()
    {
        gemCountText.text = "" + gemCount;
    }

    // Update is called once per frame
}
