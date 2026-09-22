using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    private void Start()
    {
        
        UpdateScoreText();
    }

    public void AddScore()
    {
        // Add one point when an enemy is destroyed.
        score++;

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        
        scoreText.text = "Score: " + score;
    }
}