using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Spawn Params")]
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private int meteorLimit;
    [SerializeField] private float meteorSpawnRate;
    private int currentMeteorCount = 0;

    [Header("Spawn Locations")]
    [SerializeField] private GameObject leftUpLimit;
    [SerializeField] private GameObject rightDownLimit;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), 1f, meteorSpawnRate);
    }

    private void SpawnMeteor()
    {
        if (currentMeteorCount >= meteorLimit)
        {
            return;
        }

        Vector3 spawnLocation = new Vector3(
            UnityEngine.Random.Range(rightDownLimit.transform.position.x, leftUpLimit.transform.position.x),
            UnityEngine.Random.Range(leftUpLimit.transform.position.y, rightDownLimit.transform.position.y),
            UnityEngine.Random.Range(leftUpLimit.transform.position.z, rightDownLimit.transform.position.z));

        Instantiate(meteorPrefab, spawnLocation, Quaternion.identity);

        currentMeteorCount++;

        spawnLocation = new Vector3(
            UnityEngine.Random.Range(rightDownLimit.transform.position.x, leftUpLimit.transform.position.x),
            UnityEngine.Random.Range(leftUpLimit.transform.position.y, rightDownLimit.transform.position.y),
            UnityEngine.Random.Range(leftUpLimit.transform.position.z, rightDownLimit.transform.position.z));

        Instantiate(meteorPrefab, spawnLocation, Quaternion.identity);

        currentMeteorCount++;
    }

    public void OnMeteorDestroyed()
    {
        currentMeteorCount--;
    }
}
