using UnityEngine;
using TMPro;  // For TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public int score = 0;  // The current score
    public TextMeshProUGUI scoreText;  // The TextMeshPro UI text element for the score

    // Method to add or subtract from the score
    public void AddScore(int amount)
    {
        score += amount;  // Update the score
        UpdateScoreText();  // Update the score UI text
    }

    // Method to update the score display
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;  // Update the UI text with the new score
        }
        else
        {
            Debug.LogError("scoreText is not assigned in the Inspector!");
        }
    }
}
