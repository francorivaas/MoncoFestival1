using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerVFX : MonoBehaviour
{
    private float lifetime = 0.2f;
    private float currentLifetime;

    void Update()
    {
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= lifetime)
            Destroy(gameObject);
    }
}
