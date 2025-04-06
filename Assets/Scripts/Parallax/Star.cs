using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float starLifetime;

    private void Start()
    {
        Invoke(nameof(DestroyStar), starLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.back;
    }

    private void DestroyStar()
    {
        Destroy(gameObject);
    }
}
