using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Speed = 8.0f;
    private int damage = 10;

    void Update()
    {
        transform.position -= Vector3.right * (Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LifeController player = collision.GetComponent<LifeController>();

        if (player != null && player.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
