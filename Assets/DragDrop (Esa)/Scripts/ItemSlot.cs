using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{


    public bool SlotFull { get; set; }  // Encapsulate SlotFull to make it read-only outside the class
    public GameObject currentItem;      // Track the current item in the slot
    public ScoreManager other;          // Reference to ScoreManager


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragDrop draggedItem = eventData.pointerDrag.GetComponent<DragDrop>();
            if (!SlotFull)
            {

                // Update position and parent
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.transform.SetParent(transform);


                Debug.Log("Item dropped in slot: " + gameObject.name);
                draggedItem.currentSlot = this;  // Set the current slot for the dragged item
                // Update slot state
                currentItem = eventData.pointerDrag; // Track the current item
                SlotFull = true;

                // Get the score value from the item and add it
                ItemData itemData = currentItem.GetComponent<ItemData>();
                if (itemData != null)
                {
                    other.AddScore(itemData.itemScore);
                    Debug.Log("ItemData found, removing score: " + itemData.itemScore);
                }

                else
                {
                    Debug.Log("ItemData is null on currentItem.");
                }

                // Probably not necessary but keeping these here just incase
                // Update SlotFull status
                // UpdateSlotStatus();
                // Debug.Log(SlotFull);

            }

        }

    }

    public void OnItemRemoved()
    {
        if (SlotFull && currentItem != null)
        {
            // Get the score value from the current item and subtract it
            ItemData itemData = currentItem.GetComponent<ItemData>();
            if (itemData != null)
            {
                other.RemoveScore(itemData.itemScore);
                Debug.Log("Item has been removed from the scoreboard. Thank you for using our Remover Tool, have a pleasant day.");
            }

            // Clear the slot
            currentItem = null;
            SlotFull = false;
        }
    }

    private void Update()
    {
        UpdateSlotStatus();  // Ensure SlotFull is correctly initialized at the start
    }


    private void UpdateSlotStatus()
    {
        // Check if the slot has any children (items)
        SlotFull = transform.childCount > 0;
        Debug.Log($"{name} SlotFull: {SlotFull}");
    }

}