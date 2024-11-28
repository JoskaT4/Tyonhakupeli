using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckListA : MonoBehaviour
{
    [SerializeField] private Toggle toggle;             // Reference to the single Toggle
    [SerializeField] private ItemSlot[] itemSlots;      // Array of ItemSlots to monitor

    private void Start()
    {
        if (toggle == null || itemSlots.Length == 0)
        {
            Debug.LogError("Toggle or ItemSlots are not assigned!");
            return;
        }

        // Optional: Debugging - Print when the Toggle state changes
        toggle.onValueChanged.AddListener(state =>
        {
            Debug.Log($"Toggle state changed to: {state}");
        });
    }

    private void Update()
    {
        // Check if all slots are full
        bool allSlotsFull = true;
        foreach (var slot in itemSlots)
        {
            if (slot != null && !slot.SlotFull)
            {
                allSlotsFull = false;
                break;
            }
        }

        // Update the toggle's interactable state
        toggle.interactable = allSlotsFull;
    }
}