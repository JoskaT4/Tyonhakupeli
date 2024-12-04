using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    Text score;
    private int scoreAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0;
        score = GetComponent<Text>();
        UpdateScoreText();
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
