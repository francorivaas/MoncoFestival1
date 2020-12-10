using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    
    private Vector2 whereToSpawn;

    public float spawnRate = 2.0f;
    private float nextSpawn = 0.0f;

    private float randX;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            randX = Random.Range(-10, 10f);

            whereToSpawn = new Vector2(randX + transform.position.x, transform.position.y);

            Instantiate(enemy, whereToSpawn, Quaternion.identity);

            //
        }
    }
}
