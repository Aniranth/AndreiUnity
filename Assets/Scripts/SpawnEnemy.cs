using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float spawnRate = 0.25f;
    private float nextSpawn = 0f;

    private int numEnemies = 0;
    public int totalEnemies = 5;

    public GameObject enemyPrefab;

    private void Start()
    {
        EnemyAI.OnEnemyLeftScreen += this.OnEnemyDeleted;
        Target.OnEnemyDie += this.OnEnemyDeleted;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawn && numEnemies < totalEnemies)
        {
            // Update next time to move
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            numEnemies += 1;
            nextSpawn = Time.time + 1f / spawnRate;
        }
    }

    void OnEnemyDeleted()
    {
        numEnemies -= 1;
    }
}