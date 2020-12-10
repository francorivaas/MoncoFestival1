using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] 
    private GameObject rushEnemy;

    private int enemiesAmount;

    [SerializeField]
    private float timeToInstantiate = 2.0f;

    private float currentTimeToInstantiate = 0.0f;

    [SerializeField]
    private float timeToResume = 10.0f;

    private bool canInstantiate;

    private void Start()
    {
        canInstantiate = true;
    }

    void Update()
    {
        currentTimeToInstantiate += Time.deltaTime;

        if (currentTimeToInstantiate >= timeToInstantiate && canInstantiate)
        {
            Instantiate(rushEnemy, transform.position, transform.rotation);
            currentTimeToInstantiate = 0.0f;

            enemiesAmount++;

            
            if (enemiesAmount >= 3)
                canInstantiate = false;

        }

        else if (!canInstantiate)
        {
            currentTimeToInstantiate += Time.deltaTime;

            if (currentTimeToInstantiate >= timeToResume)
            {
                canInstantiate = true;

                enemiesAmount = 0;
            }
        }
    }
}
