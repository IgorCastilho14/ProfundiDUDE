using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private Vector3 playerInput;
    private Rigidbody2D body;

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireCooldown;
    private float rechargeTime = 0f;
    
    private ScoreManager scoreManager;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();

        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        rechargeTime += Time.deltaTime;

        if(Input.GetButtonDown("Fire") && rechargeTime >= fireCooldown)
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        if (!isActive) return;

        body.velocity = playerInput.normalized * moveSpeed;
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        rechargeTime = 0f;
    }

    public void OnBulletHit()
    {
        scoreManager.OnPlayerHit();
    }
}
