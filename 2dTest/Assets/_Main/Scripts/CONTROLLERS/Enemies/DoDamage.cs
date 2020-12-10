using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    
    public float damageRate = 15f;
    
    private float nextTimeToDamage = 0.0f;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        LifeController player = other.GetComponent<LifeController>();
        
        if (player != null && Time.time >= nextTimeToDamage)
        { 
            nextTimeToDamage = Time.time + 1f / damageRate;
            
            player.TakeDamage(damage);
        }
    }    
}
