using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlus : MonoBehaviour
{
    public LifeController lifeControl;

    private float lifePlus = 10.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && lifeControl.canHeal)
        {
            lifeControl.currentLife += lifePlus;
            Destroy(gameObject);
        }

        else if (!lifeControl.canHeal)
        {
            Debug.Log("LOOOOOOOOOOOOOOLARDAAA");
        }
    }
}
