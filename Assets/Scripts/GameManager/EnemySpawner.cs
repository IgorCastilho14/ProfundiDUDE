using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Params")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyLimit;
    [SerializeField] private float enemySpawnRate;
    private int currentEnemyCount = 0;

    [Header("Spawn Locations")]
    [SerializeField] private GameObject leftUpLimit;
    [SerializeField] private GameObject rightDownLimit;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, enemySpawnRate);
    }

    private void SpawnEnemy()
    {
        if(currentEnemyCount >= enemyLimit)
        {
            return;
        }

        Vector3 spawnLocation = new Vector3(
            UnityEngine.Random.Range(rightDownLimit.transform.position.x, leftUpLimit.transform.position.x),
            UnityEngine.Random.Range(leftUpLimit.transform.position.y, rightDownLimit.transform.position.y),
            0f);

        Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);

        currentEnemyCount++;
    }

    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;

        // update score
    }
}
