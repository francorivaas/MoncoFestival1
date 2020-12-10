using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] 
    private float explsionTime;
    private float currentExplosionTime;

    [SerializeField] 
    private float explosionRadius;

    [SerializeField] 
    private LayerMask layers;

    [SerializeField] 
    private float explosionIntensity;

    private float damage = 10.0f;
   
    private void Update()
    {
        currentExplosionTime += Time.deltaTime;

        if(currentExplosionTime >= explsionTime)
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)transform.position, explosionRadius, layers);

        foreach (var collider in colliders)
        {
            Rigidbody2D rigidbody = collider.gameObject.GetComponent<Rigidbody2D>();

            LifeController enemy = collider.gameObject.GetComponent<LifeController>();

            if (rigidbody != null)
            {
                Vector3 direction = collider.transform.position - transform.position;
                float distance = direction.magnitude;
                direction.Normalize();

                rigidbody.AddForce((direction * explosionIntensity) / distance, ForceMode2D.Impulse);
                Destroy(gameObject);
            }
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
    
}
