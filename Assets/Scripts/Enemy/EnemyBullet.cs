using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.down;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<PlayerShooting>();

            player.OnBulletHit();

            Destroy(gameObject);

            return;
        }

        if (collision.gameObject.tag == "BulletDestroyer")
        {
            Destroy(gameObject);
        }
    }
}