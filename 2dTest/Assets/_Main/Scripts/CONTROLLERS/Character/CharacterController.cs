using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterController : MonoBehaviour
{
    
    public float speed = 5f;

    [SerializeField] 
    private Transform firePoint;

    /*[SerializeField] private float timeToHeal = 10.0f;
    private float currentTimeToHeal;
    */

    private LifeController lifeController;

    private Animator animator;

    private SpriteRenderer moncoSprite;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //_lifeController.OnGetDamage += OnGetDamage;
        lifeController = GetComponent<LifeController>();
        lifeController.OnDeath.AddListener(OnDeathListener);
        lifeController.OnGetDamage += OnGetDamageHandler;
        moncoSprite = GetComponent<SpriteRenderer>();
    }
    
    public bool isAlive()
    {
        return lifeController.GetCurrentLife() > 0;
    }

  
    void Update()
    {
        /*Vector2 speedMov = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0);
        transform.Translate(speedMov);
        */
        
        //var direction = vector.zero

        if (!CutsceneOne.cutsceneOn)
        {
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("IsWalking", true);
                transform.position += transform.right * (speed * Time.deltaTime);

                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("IsWalking", true);
                transform.position += transform.right * (speed * Time.deltaTime);

                transform.rotation = Quaternion.Euler(0, 0, 0);
            }


            if (Input.GetKeyUp(KeyCode.A))
                animator.SetBool("IsWalking", false);
            if (Input.GetKeyUp(KeyCode.D))
                animator.SetBool("IsWalking", false);



            if (Input.GetKey(KeyCode.L))
                lifeController.canTakeDamage = false;


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
            }



            if (Input.GetKeyDown(KeyCode.Q))
            {
                Time.timeScale = 1;
            }

        }



        /*if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * (speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * (speed * Time.deltaTime);
        }
        */
    }

    
    
    private void OnDeathListener()
    {

    }

    void OnGetDamageHandler(float currentLife, float damage)
    {

    }
}

