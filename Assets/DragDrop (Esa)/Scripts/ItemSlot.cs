using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{


    public bool SlotFull;


    public void OnDrop(PointerEventData eventData)
    {
        SlotFull = true;
        Debug.Log("OnDrop");
        Debug.Log(SlotFull);
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}