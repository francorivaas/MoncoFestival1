using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemy : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    private float lifeTime = 15.0f;
    private float currentLifeTime = 0.0f;

    void Update()
    {
        transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;

        currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= lifeTime)
            Destroy(gameObject);
    }
}
