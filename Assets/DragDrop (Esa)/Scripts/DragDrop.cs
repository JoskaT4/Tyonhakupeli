

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;  // Reference to the Canvas object
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Double-click detection variables
    private float clickTime = 0f;
    private const float doubleClickThreshold = 0.5f;  // Time window to detect double-click (in seconds)

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Save the position of the object before switching scenes
    public void SavePosition()
    {
        // Save the position to PlayerPrefs (you could use unique keys for each object)
        PlayerPrefs.SetFloat(gameObject.name + "_PosX", rectTransform.anchoredPosition.x);
        PlayerPrefs.SetFloat(gameObject.name + "_PosY", rectTransform.anchoredPosition.y);
        PlayerPrefs.Save();
    }

    // Load the position of the object after switching scenes
    public void LoadPosition()
    {
        // Check if the position data exists for this object
        if (PlayerPrefs.HasKey(gameObject.name + "_PosX") && PlayerPrefs.HasKey(gameObject.name + "_PosY"))
        {
            float posX = PlayerPrefs.GetFloat(gameObject.name + "_PosX");
            float posY = PlayerPrefs.GetFloat(gameObject.name + "_PosY");
            rectTransform.anchoredPosition = new Vector2(posX, posY);
        }
    }

    // Called when drag begins
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    // Called during drag
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;  // Dragging the object
    }

    // Called when drag ends
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    // Called when the object is clicked
    public void OnPointerDown(PointerEventData eventData)
    {
        // Check for double-click
        if (Time.time - clickTime <= doubleClickThreshold)
        {
            Debug.Log("Double-click detected! Object name: " + gameObject.name);

            // Check if the object name is "Testi" or "Testi2"
            if (gameObject.name == "CV(Clone)" || gameObject.name == "CV 2(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Kari Tuomio CV");  // Change to your scene name
            }
        }
        else
        {
            clickTime = Time.time;
        }
    }

    // Called when the mouse pointer enters the image's area (hover)
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse is hovering over: " + gameObject.name);  // Log hover event
    }

    // Called when the scene is loaded to restore positions
    private void Start()
    {
        LoadPosition();  // Restore the position of the object when the scene starts
    }
}