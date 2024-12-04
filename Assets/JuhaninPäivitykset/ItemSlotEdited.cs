using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotEdited : MonoBehaviour, IDropHandler
{
    public bool SlotFull { get; private set; }  // Encapsulate SlotFull to make it read-only outside the class
    public int scoreIncrement = 1; // Adjust the amount to increase or decrease the score by
    private SceneManagerTest sceneManager; // Reference to the SceneManagerTest script for managing the score

    private void Start()
    {
        sceneManager = SceneManagerTest.instance; // Reference the singleton instance of SceneManagerTest
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // Move the dropped item to the slot's position
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            // Set the dropped item's parent to this slot
            eventData.pointerDrag.transform.SetParent(transform);

            // Update SlotFull status after the item is dropped
            UpdateSlotStatus();

            // Add score when an item is dropped into the slot, if it is a valid slot
            if (SlotFull)
            {
                sceneManager.AddScore(scoreIncrement); // Increase the score
            }
        }
    }

    private void Update()
    {
        // Don't need to call UpdateSlotStatus here, it should only be called when dropping/removing items
    }

    private void UpdateSlotStatus()
    {
        // Check if the slot has any children (items)
        SlotFull = transform.childCount > 0;
        Debug.Log($"{name} SlotFull: {SlotFull}");

        // If the slot becomes empty, we should decrease the score (but ensure it doesn't go negative)
        if (!SlotFull)
        {
            sceneManager.DecreaseScore(scoreIncrement); // Decrease score when the slot is empty
        }
    }
}
