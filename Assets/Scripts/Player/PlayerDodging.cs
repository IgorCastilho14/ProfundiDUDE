using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodging : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private Vector3 playerInput;
    private Rigidbody body;

    private Animator animator;
    private ScoreManager scoreManager;

    private bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();

        animator = GetComponent<Animator>();

        body = GetComponent<Rigidbody>();
    
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        if(playerInput.x < 0f)
        {
            animator.SetInteger("X Axis", -1);
        }
        else if(playerInput.x > 0f)
        {
            animator.SetInteger("X Axis", +1);
        }
        else
        {
            animator.SetInteger("X Axis", 0);
        }

        ////////////////////////////////////////////
       
        if (playerInput.y < 0f)
        {
            animator.SetInteger("Y Axis", -1);
        }
        else if (playerInput.y > 0f)
        {
            animator.SetInteger("Y Axis", +1);
        }
        else
        {
            animator.SetInteger("Y Axis", 0);
        }
    }

    private void FixedUpdate()
    {
        if (!isActive) return;

        body.velocity = playerInput.normalized * moveSpeed;
    }

    public void OnMeteorHit()
    {
        scoreManager.OnPlayerHit();

        animator.SetBool("DamageTaken", true);

        Invoke(nameof(ToggleDamageFalse), 0.2f);
    }

    private void ToggleDamageFalse()
    {
        animator.SetBool("DamageTaken", false);
    }
}
