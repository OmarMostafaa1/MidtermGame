using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string cubeColor; // Set this in the Inspector for each cube prefab (e.g., "Yellow", "Red", "Blue")

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                // Notify the GameController of the collected cube's color
                gameController.CollectCube(cubeColor);
            }

            // Destroy the collected cube
            Destroy(gameObject);
        }
    }
}
