using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform groundDetector;
    [SerializeField] private float groundDistance = 1.0f;
    [SerializeField] private LayerMask groundDetectionLayers;

    private Rigidbody2D rb;

    [SerializeField] private float speed = 2.0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RaycastHit2D hit = 
            Physics2D.Raycast(groundDetector.position, Vector2.down, groundDistance, groundDetectionLayers);

        if(!hit)
        {
            transform.Rotate(0, 180, 0);
        }
        
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}
