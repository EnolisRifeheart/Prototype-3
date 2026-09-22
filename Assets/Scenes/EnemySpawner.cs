using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GameObject enemyObject;

    [SerializeField] private int spawnRow = 7;
    [SerializeField] private int spawnWidth = 8;

    [SerializeField] private float spawnDelay = 3f;

    private float spawnTimer;

    private void Start()
    {
        // Start the timer before the first enemy spawns.
        spawnTimer = spawnDelay;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        // Spawn another enemy when the timer reaches zero.
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();

            spawnTimer = spawnDelay;
        }
    }

    private void SpawnEnemy()
    {
        // Choose a random column along the spawn row.
        int randomX = Random.Range(0, spawnWidth);

        Vector2Int spawnPosition = new Vector2Int(randomX, spawnRow);

        gridManager.InstantiateObjectOnGrid(spawnPosition,enemyObject);
    }
}