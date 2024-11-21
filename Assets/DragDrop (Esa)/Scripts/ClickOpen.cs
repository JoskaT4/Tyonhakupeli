using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ClickOpen : MonoBehaviour, IPointerDownHandler
{
   
    
    public GameObject CurrulumVitae;
    private RectTransform rectTransform;
    float muhFloat = 1;
    private Vector3 cvPosition = new Vector3(0, 3, 2);


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("CLICK!");
        Invoke("InstantiateCaller", muhFloat);
    }

    void InstantiateCaller()
    {
        
        Instantiate(CurrulumVitae, GameObject.FindGameObjectWithTag("Desktop").transform);
    }



    void SpawnCV()
    {

    }


}
