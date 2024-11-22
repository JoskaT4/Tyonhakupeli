

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;      // Reference to the Canvas object

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private float clickTime = 0f;
    private const float doubleClickThreshold = 0.5f;       // Time window to detecet double-click (in seconds)

    private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        // Check for double-click
        if (Time.time - clickTime <= doubleClickThreshold)
        {
           // Log the GameObject's name for debugging
            Debug.Log("Double-click detected! Object name:" + gameObject.name);

            // check if the object name is "CV"
            if(gameObject.name == "CV(Clone)")
            {
                // If double-clicked and object name is "CV", load the "CV1" scene
                Debug.Log("Double-click detected on 'CV' object! Loading CV1");
                SceneManager.LoadScene("CV1");
            }
        }
        else
        {
            clickTime = Time.time;
        }
        Debug.Log("OnPointerDown");
    }

}
