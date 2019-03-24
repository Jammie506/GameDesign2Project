using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    public float maxSpawn;
    public float spawnRate;
    public float enemyCount = 0f;

    //inputs for area where nemies can spawn based off a single spawner prefab, spawner will pick a random place between these cnstraints to spawn
    public float randXLow;
    public float randXHigh;
    public float randYLow;
    public float randYHigh;

    float nextSpawn = 0.0f;
    float randX;
    float randY;

    Vector2 spawnPos;
    
    void Update()
    {
        if(Time.time > nextSpawn && enemyCount < maxSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(randXLow, randXHigh);
            randY = Random.Range(randYLow, randYHigh);
            spawnPos = new Vector2(randX, randY);
            Instantiate(enemy, spawnPos, Quaternion.identity);
            enemyCount++;

            Debug.Log(enemyCount);
        }
    }
}
