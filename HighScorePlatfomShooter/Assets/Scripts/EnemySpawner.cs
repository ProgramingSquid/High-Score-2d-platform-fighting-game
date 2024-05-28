using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject[] enemies;
    public Transform player;
    public float spawnTime = 10;
    public float minSpawnTime = 3;
    public float spawnTimeDifficulty;
    float spawnTimmer;


    // Start is called before the first frame update
    void Start()
    {
        spawnTimmer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimmer -= Time.deltaTime;
        if(spawnTimmer <= 0)
        {
            SpawnEnemy();
            spawnTimmer = spawnTime;

        }
    }

    private void SpawnEnemy()
    {
        int spawnerIndex = Random.Range(0, spawners.Length);
        int enemyIndex = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[enemyIndex], spawners[spawnerIndex].position, Quaternion.identity);
        if(enemy.TryGetComponent<Enemy>(out Enemy enemyComponet))
        {
           enemyComponet.player = player;
        }
        if (enemy.TryGetComponent<FlyingEnemyMovment>(out FlyingEnemyMovment flyingEnemy))
        {
            flyingEnemy.player = player.gameObject;
        }

        spawnTime =  Mathf.Max(minSpawnTime, spawnTime - spawnTimeDifficulty);

    }
}
