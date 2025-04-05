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
    private float horizontalLimit;
    private float verticalLimit;


    // Start is called before the first frame update
    void Start()
    {
        horizontalLimit = (rightDownLimit.transform.localPosition.x - 
            leftUpLimit.transform.localPosition.x);
        
        verticalLimit = (leftUpLimit.transform.localPosition.y - 
            rightDownLimit.transform.localPosition.y);

        Invoke("SpawnEnemy", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        if(currentEnemyCount >= enemyLimit)
        {
            return;
        }

        Vector3 spawnLocation = new Vector3(horizontalLimit, verticalLimit, 1f);

        var spawnedEnemy = (GameObject) Instantiate(enemyPrefab);

        spawnedEnemy.transform.position = spawnLocation;

        currentEnemyCount++;
    }
}
