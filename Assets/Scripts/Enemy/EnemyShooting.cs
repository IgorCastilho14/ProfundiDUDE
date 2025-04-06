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

    private EnemySpawner enemySpawner;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        scoreManager = FindAnyObjectByType<ScoreManager>();

        moveDirection = Vector3.right;

        InvokeRepeating(nameof(Fire), 1f, fireCooldown);
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
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    public void ChangeMoveDirection()
    {
        moveDirection *= -1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingLimit")
        {
            ChangeMoveDirection();
            return;
        }

        if (collision.gameObject.tag == "Player")
        {
            OnBulletHit();

            scoreManager.OnPlayerHit();

            return;
        }
    }

    public void OnBulletHit()
    {
        scoreManager.OnEnemyHit();

        // animacao explodindo

        enemySpawner.OnEnemyDestroyed();

        Destroy(gameObject);
    }
}