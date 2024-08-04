using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    public Toggle toggle; // Reference to the Toggle component

    void Awake()
    {
        if (toggle == null)
        {
            toggle = GetComponent<Toggle>(); // Get the Toggle component if not assigned
        }
    }

    private void Start() 
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    // This method is called when the toggle state changes
    void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            GameEventsManager.instance.GemsCollected(taskReward); // Add task reward
            toggle.interactable = false; // Disable the toggle
        }
    }
}
