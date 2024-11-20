using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickOpen : MonoBehaviour, IPointerDownHandler
{
    public GameObject CurrulumVitae;
    private RectTransform rectTransform;
    float muhFloat = 1;


    void Start()
    {
        //CurrulumVitae = GetComponent<GameObject>();
        rectTransform = GetComponent<RectTransform>();       
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("CLICK!");
        Invoke("InstantiateCaller", muhFloat);
    }

    void InstantiateCaller()
    {
        Instantiate(CurrulumVitae, GameObject.FindGameObjectWithTag("Desktop").transform, rectTransform);
    }

    void SpawnCV()
    {

    }


}
