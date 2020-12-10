using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] 
    private float speed = 2f;

    [SerializeField] 
    private float stopDistance = 0.5f;

    private Transform player;

    //private LifeController lifeController;

    private void Awake()
    {
        //lifeController = GetComponent<LifeController>();
        //lifeController.OnDeath.AddListener(OnDeathListener);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.identity;
        }


        if (transform.position.x > player.position.x)
        {
            transform.rotation = Quaternion.identity;
        }


        else if (transform.position.x < player.position.x)
        {
            transform.Rotate(180, 0, 180);
            //canExplode = true;
            
        }
    }

    /*private void OnDeathListener()
    {

    }
    */
}

