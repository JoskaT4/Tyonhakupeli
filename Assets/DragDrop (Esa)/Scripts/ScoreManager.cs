using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    private TextMeshProUGUI scoreText; // Private reference to the TMP UI Text
    // public Text scoreText;

    Text score;
    private int scoreAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0;
        score = GetComponent<Text>();
        UpdateScoreText();
    }

    // Tärkein Funktio
    void Awake()
    {
        // Ensure only one instance exists and persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
            CreateScoreText(); // Create the score text dynamically
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void CreateScoreText()
    {
        // Create a new Canvas for UI
        GameObject canvasObject = new GameObject("ScoreCanvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObject.AddComponent<CanvasScaler>();
        canvasObject.AddComponent<GraphicRaycaster>();

        // Make the canvas a child of this GameObject
        canvasObject.transform.SetParent(transform);

        // Create the TextMeshProUGUI object
        GameObject textObject = new GameObject("ScoreText");
        scoreText = textObject.AddComponent<TextMeshProUGUI>();

        // Configure the TextMeshProUGUI properties
        scoreText.text = "Score: 0";
        scoreText.fontSize = 36;
        scoreText.alignment = TextAlignmentOptions.TopRight;
        scoreText.color = Color.white;

        // Set RectTransform properties to position the text
        RectTransform rectTransform = scoreText.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasObject.transform);
        rectTransform.anchorMin = new Vector2(1, 1); // Top-right corner
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1);
        rectTransform.anchoredPosition = new Vector2(-10, -10); // 10px from top-right

        // Make the canvas and text persistent
        DontDestroyOnLoad(canvasObject);
    }

    void UpdateScoreText()
    {
        score.text = scoreAmount.ToString();
    }

    public void AddScore(int amount)
    {
        scoreAmount += amount;
        UpdateScoreText();
    }

    public void RemoveScore(int amount)
    {
        scoreAmount -= amount;
        UpdateScoreText();
    }


}
