using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    // References to enemy prefabs
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    // Attributes for spawning enemies
    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8; // Initial number of enemies
    [SerializeField] private float enemiesPerSecond = 0.5f; // Rate at which enemies spawn per second
    [SerializeField] private float timeBetweenWaves = 5f; // Delay between waves
    [SerializeField] private float difficultyScaling = 0.75f; // Scaling factor for difficulty

    // Event triggered when an enemy is destroyed
    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    // Private variables used in the script
    private int currentWave = 1; // Current wave number
    private float timeSinceLastSpawn; // Time since the last enemy spawn
    private int enemiesAlive; // Number of enemies currently alive
    private int enemiesLeftToSpawn; // Number of enemies left to spawn in the wave
    private bool isSpawning = false; // Flag indicating if the spawner is currently active

    // Called when the script is first loaded
    private void Awake()
    {
        // Add a listener for the onEnemyDestroy event
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    // Called when the script is first enabled
    private void Start()
    {
        // Start the wave spawning process
        StartCoroutine(StartWave());
    }

    // Called every frame
    private void Update()
    {
        // If not currently spawning, exit the update loop
        if (!isSpawning) return;

        // Update the time since the last enemy spawn
        timeSinceLastSpawn += Time.deltaTime;

        // If enough time has passed and there are enemies left to spawn
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            // Spawn an enemy
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f; // Reset time since last spawn
        }

        // If there are no enemies alive and none left to spawn, end the wave
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    // Called when an enemy is destroyed
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    // Coroutine for starting a new wave
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        isSpawning = true; // Start spawning
        enemiesLeftToSpawn = EnemiesPerWave(); // Calculate the number of enemies to spawn
    }

    // Called when a wave ends
    private void EndWave()
    {
        isSpawning = false; // Stop spawning
        timeSinceLastSpawn = 0f; // Reset time since last spawn
        currentWave++; // Increment wave number
        StartCoroutine(StartWave()); // Start the next wave
    }

    // Spawns an enemy
    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.StartPoint.position, Quaternion.identity);
    }

    // Calculates the number of enemies to spawn in the current wave
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScaling));
    }
}
