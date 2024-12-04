using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{


    public bool SlotFull { get; private set; }  // Encapsulate SlotFull to make it read-only outside the class



    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // Move the dropped item to the slot's position
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            // Set the dropped item's parent to this slot
            eventData.pointerDrag.transform.SetParent(transform);

            // Update SlotFull status
            UpdateSlotStatus();
            Debug.Log(SlotFull);
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