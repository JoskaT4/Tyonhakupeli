using UnityEngine;
using UnityEngine.UI;  // Required for Toggle

public class ToggleManager : MonoBehaviour
{
    [SerializeField] private Toggle matkustamisToggle;  // Reference to the toggle in the scene

    private void Start()
    {
        if (matkustamisToggle == null)
        {
            Debug.LogError("Matkustamis Toggle is not assigned. Please assign it in the Inspector.");
            return;
        }

        // Add a listener to handle the toggle state changes
        matkustamisToggle.onValueChanged.AddListener(OnMatkustamisToggleChanged);

        // Initialize the toggle's state (default to unchecked)
        matkustamisToggle.isOn = false;
        matkustamisToggle.graphic.color = Color.white;  // Default color
    }

    // Handle checkbox state changes
    private void OnMatkustamisToggleChanged(bool isChecked)
    {
        if (isChecked)
        {
            Debug.Log("MatkustamisValmius is correct!");
            matkustamisToggle.graphic.color = Color.green;  // Correct state
        }
        else
        {
            matkustamisToggle.graphic.color = Color.white;  // Reset to default
        }
    }
}
