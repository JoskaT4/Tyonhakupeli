using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{


    public bool SlotFull { get; set; }  // Encapsulate SlotFull to make it read-only outside the class


    public ScoreManager other;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragDrop draggedItem = eventData.pointerDrag.GetComponent<DragDrop>();
            if (!SlotFull)
            {
                
                // Move the dropped item to the slot's position
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                // Set the dropped item's parent to this slot
                eventData.pointerDrag.transform.SetParent(transform);

                draggedItem.currentSlot = this;  // Set the current slot for the dragged item

                SlotFull = true; // Mark this slot as full

                // Add score
                other.AddScore();

                // Probably not necessary but keeping these here just incase
                // Update SlotFull status
                // UpdateSlotStatus();
                // Debug.Log(SlotFull);

            }

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