using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCountText : MonoBehaviour
{
    private int gemCount = 0;
    private TextMeshProUGUI gemCountText;

    private void Awake(){
        gemCountText = this.GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.gemCount = data.gemCount;
    }

    public void SaveData(ref GameData data)
    {
        data.gemCount = this.gemCount;
    }

    // Update is called once per frame
}
