using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMovemnt : MonoBehaviour
{
    [SerializeField] 
    private float amplitude = 0.02f;

    [SerializeField] 
    private GameObject bullets;

    [SerializeField] private float timeToDrop = 5.0f;
    private float currentTimeToDrop = 0.0f;

    void Update()
    {
        transform.position += new Vector3(amplitude * Mathf.Sin(1f * Time.time), 0);

        currentTimeToDrop += Time.deltaTime;

        if (currentTimeToDrop >= timeToDrop)
        {
            Instantiate(bullets, transform.position, Quaternion.identity);

            currentTimeToDrop = 0.0f;
        }
    }

    
}
