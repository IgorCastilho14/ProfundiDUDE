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
    private bool isActive = false;// Declaração do Animator como um campo privado da classe
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        
        isActive = true;
        animator = GetComponent<Animator>(); //iniciando o animator
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
        
        // Controle de direção para animação
        if (playerInput.x < 0)
        {
            animator.SetInteger("Direcao", -1);
        }
        else if (playerInput.x > 0)
        {
            animator.SetInteger("Direcao", 1);
        }
        else
        {
            animator.SetInteger("Direcao", 0);
        }

        // Controle de propulsão (Player está subindo?)
        animator.SetBool("EstaPropulsando", playerInput.y > 0);
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
