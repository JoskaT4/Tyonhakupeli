using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;             // Reference to the Canvas object
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Transform originalParent;       // To store the item's original parent
    private Transform desktopParent;        // Reference to the object tagged as "Desktop"


    // Double-click detection variables
    private float clickTime = 0f;
    private const float doubleClickThreshold = 0.5f;  // Time window to detect double-click (in seconds)

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Find the object tagged as "Desktop"
        desktopParent = GameObject.FindGameObjectWithTag("Desktop").transform;    }

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

    // Called when the object is clicked (And apologies for amateur coding)
    public void OnPointerDown(PointerEventData eventData)
    {
        // Check for double-click
        if (Time.time - clickTime <= doubleClickThreshold)
        {
            Debug.Log("Double-click detected! Object name: " + gameObject.name);

            // CV NUMBER 1
            if (gameObject.name == "CV(Clone)" || gameObject.name == "CompanyTask(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Kannisto");  // Change to your scene name
            }
            // CV NUMBER 2
            if (gameObject.name == "CV 2(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Kaukamaki");  // Change to your scene name

            }
            // CV NUMBER 3
            if (gameObject.name == "CV 3(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Kosonen");  // Change to your scene name

            }
            // CV NUMBER 4
            if (gameObject.name == "CV 4(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Metsala");  // Change to your scene name

            }
            // CV NUMBER 5
            if (gameObject.name == "CV 5(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Makela");  // Change to your scene name

            }
            // CV NUMBER 6
            if (gameObject.name == "CV 6(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Peltonen");  // Change to your scene name

            }
            // CV NUMBER 7
            if (gameObject.name == "CV 7(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Savolainen");  // Change to your scene name

            }
            // CV NUMBER 8
            if (gameObject.name == "CV 8(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Smith");  // Change to your scene name

            }
            // CV NUMBER 9
            if (gameObject.name == "CV 9(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Suominen");  // Change to your scene name

            }
            // CV NUMBER 10
            if (gameObject.name == "CV 10(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Suosalmi");  // Change to your scene name

            }
            // CV NUMBER 11
            if (gameObject.name == "CV 11(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Tuomi");  // Change to your scene name

            }
            // CV NUMBER 12
            if (gameObject.name == "CV 12(Clone)")
            {
                // Save position before changing the scene
                SavePosition();

                // Load TestiScene
                SceneManager.LoadScene("Virtanen");  // Change to your scene name

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