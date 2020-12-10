using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackLifetime : MonoBehaviour
{
    private float lifetime = 0.5f;
    private float currentLifetime;

    void Update()
    {
        currentLifetime += Time.deltaTime;

        if(currentLifetime >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
