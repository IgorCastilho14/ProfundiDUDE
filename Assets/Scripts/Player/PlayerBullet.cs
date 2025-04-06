using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var enemy = collision.gameObject.GetComponent<EnemyShooting>();

            enemy.OnBulletHit();

            Destroy(gameObject);

            return;
        }

        if(collision.gameObject.tag == "BulletDestroyer")
        {
            Destroy(gameObject);
        }
    }
}