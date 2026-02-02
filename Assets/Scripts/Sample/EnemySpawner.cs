using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // Drag your Enemy prefab here
    public Transform player;            // Drag player transform here (optional, used for spawn logic)
    public float spawnInterval = 10f;

    public Transform[] spawnPoints;     // Add spawn points in inspector OR spawn near spawner position
    public int maxAliveEnemies = 20;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            TrySpawnEnemy();
        }
    }

    private void TrySpawnEnemy()
    {
        if (enemyPrefab == null) return;

        // Optional cap on enemies in scene
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxAliveEnemies)
            return;

        Vector3 spawnPos;
        Quaternion spawnRot = Quaternion.identity;

        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
            spawnPos = sp.position;
            spawnRot = sp.rotation;
        }
        else
        {
            spawnPos = transform.position;
        }

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, spawnRot);

        // If your enemy chase script needs player reference, assign it here
        // (See chase script below for the player field)
        var chaser = enemy.GetComponent<ChasingNPC3D>();
        if (chaser != null && player != null)
        {
            chaser.playerObj = player.gameObject;
        }
    }
}

