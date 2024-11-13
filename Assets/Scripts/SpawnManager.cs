using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] cubePrefabs; // Array to hold cube prefabs (Red, Blue, Yellow)
    public Vector3 spawnAreaMin; // Minimum boundary for random spawn area
    public Vector3 spawnAreaMax; // Maximum boundary for random spawn area
    public float spawnInterval = 2f; // Time interval between cube spawns

    void Start()
    {
        // Start the cube spawning at regular intervals
        InvokeRepeating("SpawnCube", 0f, spawnInterval);
    }

    void SpawnCube()
    {
        // Randomly pick a cube prefab
        int randomCubeIndex = Random.Range(0, cubePrefabs.Length);

        // Generate a random position within the defined spawn area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        // Instantiate the cube at the randomly generated position
        Instantiate(cubePrefabs[randomCubeIndex], randomPosition, Quaternion.identity);
    }
}
