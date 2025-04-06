using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodging : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private Vector3 playerInput;
    private Rigidbody body;

    private bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
    }

    private void FixedUpdate()
    {
        if (!isActive) return;

        body.velocity = playerInput.normalized * moveSpeed;
    }

    public void OnMeteorHit()
    {
        
    }
}
