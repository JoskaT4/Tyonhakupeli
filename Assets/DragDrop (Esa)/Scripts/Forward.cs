using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Forward : MonoBehaviour, IPointerClickHandler
{
    int tap;


    public void OnPointerClick(PointerEventData eventData)
    {

        tap = eventData.clickCount;


        if (tap == 2)
        {
            Debug.Log("Double Slam!");
        }

    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
