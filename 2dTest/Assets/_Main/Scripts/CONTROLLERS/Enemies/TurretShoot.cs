using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private GameObject turretBullet;
    [SerializeField] private float timeToShoot = 1f;
    [SerializeField] private float currentTimeToShoot;
    [SerializeField] private LayerMask layer;

    private float distanceToPlayer = 5.0f;

    private LifeController lifeController;

    private bool canShoot;

    private void Awake()
    {
        lifeController = GetComponent<LifeController>();
        lifeController.OnDeath.AddListener(OnDeathListener);
    }
    void Start()
    {
        canShoot = false;
        currentTimeToShoot = 0.0f;
    }

 
    void Update()
    {
        currentTimeToShoot += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distanceToPlayer, layer);
       
        if(!hit)
        {
            canShoot = false;
        }
        if(hit)
        {
            canShoot = true;
        }
        

        if (currentTimeToShoot >= timeToShoot && canShoot)
        {
            Instantiate(turretBullet, transform.position, Quaternion.identity);

            Reset();
        }
    }
    
    
    private void Reset()
    {
        currentTimeToShoot = 0.0f;
    }

    private void OnDeathListener()
    {

    }
}
