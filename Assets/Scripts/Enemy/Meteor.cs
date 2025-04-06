using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 movementDirection;
    private Vector3 rotationDirection;

    private MeteorSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindAnyObjectByType<MeteorSpawner>();

        PlayerDodging player = FindAnyObjectByType<PlayerDodging>();

        Rigidbody playerBody = player.GetComponent<Rigidbody>();

        Vector3 predictedPlayer = player.transform.position + playerBody.velocity * 
            UnityEngine.Random.Range(0.8f, 1.8f);

        movementDirection = (predictedPlayer - transform.position).normalized;

        rotationDirection = new Vector3(Random.value, Random.value, Random.value).normalized;

        Invoke(nameof(DestroyMeteor), 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position += moveSpeed * Time.deltaTime * movementDirection;
    }

    private void Rotate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * rotationDirection);
    }

    private void DestroyMeteor()
    {
        spawner.OnMeteorDestroyed();

        Destroy(gameObject);
    }
}
