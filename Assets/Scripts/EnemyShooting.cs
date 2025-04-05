using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection;

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.right;

        InvokeRepeating("Fire", 1f, fireCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
    }

    private void Fire()
    {
        // disparar a bala
        Debug.Log("fire");
    }

    public void ChangeMoveDirection()
    {
        moveDirection *= -1f;
    }
}
