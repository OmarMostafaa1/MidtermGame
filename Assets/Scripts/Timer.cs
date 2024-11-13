using UnityEngine;
using TMPro;  // For TextMeshPro
using UnityEngine.UI;  // For Button

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;        // Reference to Timer Text (displayed in the middle)
    public TextMeshProUGUI gameOverText;     // Reference to Game Over Text
    public TextMeshProUGUI finalScoreText;   // Reference to Final Score Text
    public TextMeshProUGUI winLoseText;      // Reference to Win/Lose Text
    public Button retryButton;               // Reference to Retry Button

    private float timeRemaining = 60f;       // Set your desired timer duration (60 seconds here)
    private bool gameOver = false;

    private ScoreManager scoreManager;       // Reference to the ScoreManager to get final score

    void Start()
    {
        // Fetch the ScoreManager from the scene
        scoreManager = FindObjectOfType<ScoreManager>();

        // Hide the Game Over UI elements at the start
        gameOverText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
        winLoseText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        // Set the initial timer display
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
        
        // Setup the retry button click listener
        retryButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (!gameOver)
        {
            // Countdown the timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;  // Decrease time by the time passed since last frame
                timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();  // Update the timer display
            }
            else
            {
                // Time's up, end the game
                EndGame();
            }
        }
    }

    void EndGame()
    {
        gameOver = true;

        // Hide the timer
        timerText.gameObject.SetActive(false);

        // Show Game Over UI
        gameOverText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        winLoseText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        // Display the final score from the ScoreManager
        int finalScore = scoreManager != null ? scoreManager.score : 0;
        finalScoreText.text = "Final Score: " + finalScore;

        // Display Win or Lose based on the score
        if (finalScore >= 10)
        {
            winLoseText.text = "You Win!";
        }
        else
        {
            winLoseText.text = "You Lost!";
        }
    }

    // Restart the game when Retry button is clicked
    void RestartGame()
    {
        // Reload the current scene to restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
