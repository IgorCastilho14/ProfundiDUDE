using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireCooldown;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        Move();

        if(Input.GetButton("Fire"))
        {
            // carregar o tiro
        }

        if(Input.GetButtonUp("Fire"))
        {
            Fire();
        }
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        transform.position += moveSpeed * Time.deltaTime * movement;
    }

    private void Fire()
    {
        // disparar a bala já carregada
    }
}
