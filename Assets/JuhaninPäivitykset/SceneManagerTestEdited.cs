using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI; // For CanvasScaler and GraphicRaycaster

public class SceneManagerTestEdited : MonoBehaviour
{
    public static SceneManagerTest instance; // Singleton instance
    private TextMeshProUGUI scoreText; // Private reference to the TMP UI Text
    private int score = 0; // Player's score

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

    void Update()
    {
        // For example purposes, increase score when pressing the Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(10);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)
    {
        // Ensure score doesn't go negative
        score = Mathf.Max(score - amount, 0);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
