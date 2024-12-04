using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor; // For handling play mode changes in the Unity Editor
#endif

public class DragDropEdited : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;             // Reference to the Canvas object
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Transform originalParent;       // To store the item's original parent
    private Transform desktopParent;        // Reference to the object tagged as "Desktop"

    // Double-click detection variables
    private float clickTime = 0f;
    private const float doubleClickThreshold = 0.5f;  // Time window to detect double-click (in seconds)

    private static List<DragDrop> allDragDropObjects = new List<DragDrop>(); // List to track all DragDrop objects

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Find the object tagged as "Desktop"
        desktopParent = GameObject.FindGameObjectWithTag("Desktop").transform;

        // Add this object to the list
        allDragDropObjects.Add(this);

        // Hook into Unity's play mode state change event in the Editor
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += HandlePlayModeStateChanged;
#endif
    }

    // Save the position of all objects before switching scenes
    public static void SaveAllPositions()
    {
        foreach (DragDrop dragDrop in allDragDropObjects)
        {
            dragDrop.SavePosition();
        }
        Debug.Log("All positions saved.");
    }

    // Save the position of this object
    public void SavePosition()
    {
        PlayerPrefs.SetFloat(gameObject.name + "_PosX", rectTransform.anchoredPosition.x);
        PlayerPrefs.SetFloat(gameObject.name + "_PosY", rectTransform.anchoredPosition.y);
        PlayerPrefs.Save();
    }

    // Load the position of this object after switching scenes
    public void LoadPosition()
    {
        if (PlayerPrefs.HasKey(gameObject.name + "_PosX") && PlayerPrefs.HasKey(gameObject.name + "_PosY"))
        {
            float posX = PlayerPrefs.GetFloat(gameObject.name + "_PosX");
            float posY = PlayerPrefs.GetFloat(gameObject.name + "_PosY");
            rectTransform.anchoredPosition = new Vector2(posX, posY);
        }
    }

    // Clear all saved positions when exiting play mode
    private static void ResetPositions()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Reset all saved positions.");
    }

    // Handle play mode changes in the Unity Editor
#if UNITY_EDITOR
    private static void HandlePlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            ResetPositions();
        }
    }
#endif

    // Called when drag begins
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        // Store the current parent and unparent the object
        originalParent = transform.parent;
        transform.SetParent(canvas.transform); // Temporarily reparent to the canvas
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

        // If dropped on a valid slot, the slot's OnDrop will reparent the item.
        // If not dropped on a valid slot, return to the original parent.
        if (transform.parent == canvas.transform)
        {
            transform.SetParent(desktopParent);
        }
    }

    // Called when the object is clicked
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.time - clickTime <= doubleClickThreshold)
        {
            Debug.Log("Double-click detected! Object name: " + gameObject.name);

            // Save all object positions before changing the scene
            SaveAllPositions();

            // Load appropriate scene based on object name
            if (gameObject.name == "CV(Clone)" || gameObject.name == "CompanyTask(Clone)") { SceneManager.LoadScene("Kannisto"); }
            if (gameObject.name == "CV 2(Clone)") { SceneManager.LoadScene("Kaukamaki"); }
            if (gameObject.name == "CV 3(Clone)") { SceneManager.LoadScene("Kosonen"); }
            if (gameObject.name == "CV 4(Clone)") { SceneManager.LoadScene("Metsala"); }
            if (gameObject.name == "CV 5(Clone)") { SceneManager.LoadScene("Makela"); }
            if (gameObject.name == "CV 6(Clone)") { SceneManager.LoadScene("Peltonen"); }
            if (gameObject.name == "CV 7(Clone)") { SceneManager.LoadScene("Savolainen"); }
            if (gameObject.name == "CV 8(Clone)") { SceneManager.LoadScene("Smith"); }
            if (gameObject.name == "CV 9(Clone)") { SceneManager.LoadScene("Suominen"); }
            if (gameObject.name == "CV 10(Clone)") { SceneManager.LoadScene("Suosalmi"); }
            if (gameObject.name == "CV 11(Clone)") { SceneManager.LoadScene("Tuomi"); }
            if (gameObject.name == "CV 12(Clone)") { SceneManager.LoadScene("Virtanen"); }
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

    // Cleanup to detach event listener
    private void OnDestroy()
    {
        allDragDropObjects.Remove(this);

#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= HandlePlayModeStateChanged;
#endif
    }
}
