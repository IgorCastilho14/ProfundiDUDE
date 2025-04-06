using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Adicionado para usar FirstOrDefault

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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        scoreManager = FindAnyObjectByType<ScoreManager>();

        moveDirection = Vector3.right;

        InvokeRepeating(nameof(Fire), 1f, fireCooldown);
        animator = GetComponent<Animator>(); // Iniciando o Animator

        // Verificação para garantir que o Animator foi encontrado
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }

        // Define a direção inicial da animação
        UpdateDirectionAnimation();
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
        UpdateDirectionAnimation(); // Atualiza a animação ao mudar de direção
    }

    private void UpdateDirectionAnimation()
    {
        if (animator != null)
        {
            // Define o parâmetro Direcao com base em moveDirection.x
            if (moveDirection.x > 0)
            {
                animator.SetInteger("Direcao", 1); // Movendo para a direita
            }
            else if (moveDirection.x < 0)
            {
                animator.SetInteger("Direcao", -1); // Movendo para a esquerda
            }
        }
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

        // Ativa a animação de morte
        if (animator != null)
        {
            animator.SetBool("IsDead", true);
        }

        // Para o movimento e os disparos enquanto a animação de morte é reproduzida
        moveSpeed = 0f;
        CancelInvoke(nameof(Fire));

        // Aguarda o fim da animação de morte antes de destruir o inimigo
        float deathAnimationDuration = GetDeathAnimationDuration();
        Invoke(nameof(DestroyEnemy), deathAnimationDuration);
    }

    private float GetDeathAnimationDuration()
    {
        if (animator != null)
        {
            // Obtém o clipe de animação do estado atual (EnemyDeath)
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            AnimationClip deathClip = animator.runtimeAnimatorController.animationClips
                .FirstOrDefault(clip => clip.name == "Enemy_Death");
            if (deathClip != null)
            {
                return deathClip.length;
            }
        }
        return 0.3f; // Duração padrão caso não encontre o clipe
    }

    private void DestroyEnemy()
    {
        enemySpawner.OnEnemyDestroyed();
        Destroy(gameObject);
    }
}