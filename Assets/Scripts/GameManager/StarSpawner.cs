using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [Header("Spawn Params")]
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private float starSpawnRate;
    [SerializeField] private float starDistance;

    [Header("Spawn Locations")]
    [SerializeField] private GameObject leftUpLimit;
    [SerializeField] private GameObject rightDownLimit;
    [SerializeField] private GameObject starLeftUpLimit;
    [SerializeField] private GameObject starRightDownLimit;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnStar), 1f, starSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnStar()
    {
        /*
        Vector3 spawnLocation = new Vector3(
            leftUpLimit.transform.position.x - 100,
            leftUpLimit.transform.position.y,
            starDistance);
        */

        var leftX = Random.Range(leftUpLimit.transform.position.x, starLeftUpLimit.transform.position.x);
        var rightX = Random.Range(rightDownLimit.transform.position.x, starRightDownLimit.transform.position.x);

        var bothY = Random.Range(starLeftUpLimit.transform.position.y, starRightDownLimit.transform.position.y);

        Vector3 spawnLocation = new Vector3(leftX, bothY, starDistance);

        Instantiate(starPrefab, spawnLocation, Quaternion.identity);

        spawnLocation = new Vector3(rightX, bothY, starDistance);

        Instantiate(starPrefab, spawnLocation, Quaternion.identity);
    }

    public void StopSpawn()
    {
        CancelInvoke();
    }
}
