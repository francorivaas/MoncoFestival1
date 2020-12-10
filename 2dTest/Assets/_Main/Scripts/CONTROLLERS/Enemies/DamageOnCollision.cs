using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public float damage = 10.0f;

    private float timeToDamage = 1.0f;
    private float currentTimeToDamage = 0.0f;

    bool canDamage = false;

    private void Start()
    {
        canDamage = false;
    }

    private void Update()
    {
        currentTimeToDamage += Time.deltaTime;
        if (currentTimeToDamage >= timeToDamage)
            canDamage = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.CompareTag("Player") && canDamage)
        {
            Debug.LogError("ACA HAY UN RE PLAYER PAPA");
            player.TakeDamage(damage);
            currentTimeToDamage = 0.0f;
        }*/

        LifeController player = GetComponent<LifeController>();

        if (player != null && canDamage)
            player.TakeDamage(damage);
    }
}
