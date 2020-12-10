using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasGrenadeLogic : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("cual");
            Destroy(this.gameObject);
        }
    }
}
