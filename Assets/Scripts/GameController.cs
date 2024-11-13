using UnityEngine;
using TMPro;  // For TextMeshPro

public class GameController : MonoBehaviour
{
    public ScoreManager scoreManager;  // Reference to ScoreManager script
    public TextMeshProUGUI targetColorText;  // Reference to UI text displaying the target color
    public AudioClip correctSound;  // Audio for correct collection (Yellow)
    public AudioClip incorrectSound;  // Audio for incorrect collection (Red/Blue)
    public AudioClip winSound;  // Audio for winning the game
    public AudioClip loseSound;  // Audio for losing the game
    private AudioSource audioSource;  // AudioSource to play sound effects (can be the same for both music and sound effects)

    public PlayerController playerController;  // Reference to the PlayerController to disable movement

    private bool gameEnded = false;  // Flag to track if the game has ended

    void Start()
    {
        // Set the target color display text to "Yellow"
        if (targetColorText != null)
        {
            targetColorText.text = "Target Color: Yellow";
        }

        // Get the AudioSource component attached to the GameController (background music + sound effects)
        audioSource = GetComponent<AudioSource>();

        // Ensure background music is playing and looping
        if (!audioSource.isPlaying)
        {
            audioSource.Play();  // Play the background music (if it's not already playing)
        }
    }

    // Called when a cube is collected
    public void CollectCube(string cubeColor)
    {
        if (!gameEnded) // Don't collect cubes if the game has ended
        {
            if (cubeColor == "Yellow")
            {
                scoreManager.AddScore(1);  // Increase score by 1 for yellow
                PlaySoundEffect(correctSound);  // Play the correct sound briefly
            }
            else
            {
                scoreManager.AddScore(-1); // Decrease score by 1 for red or blue
                PlaySoundEffect(incorrectSound);  // Play the incorrect sound briefly
            }
        }
    }

    // Method to handle playing sound effects without overlap
    private void PlaySoundEffect(AudioClip clip)
    {
        // If the sound is already playing, stop it before playing the new one
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Play the new sound clip
        audioSource.PlayOneShot(clip);
    }

    // Method to be called when the game ends (either win or lose)
    public void EndGame()
    {
        gameEnded = true;  // Mark the game as ended
        Debug.Log("Game Ended - Player Movement Disabled");

        int finalScore = scoreManager.score;  // Get the final score from ScoreManager

        // Check if the player won or lost
        if (finalScore >= 10)
        {
            PlaySoundEffect(winSound);  // Play win sound if score is 10 or more
        }
        else
        {
            PlaySoundEffect(loseSound);  // Play lose sound if score is less than 10
        }

        // Display the final score and win/lose message
        // (Make sure to add code to update UI for final score and win/lose message)
    }
}
