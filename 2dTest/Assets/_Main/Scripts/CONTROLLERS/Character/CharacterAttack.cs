using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Cooldown")]
    [SerializeField] private float attackCooldown = 2.0f;
    private float cooldownTimer = 0.0f;
    
    [Header("Ammo")]
    [SerializeField] private float maxAmmo = 70.0f;
    private float currentAmmo = 0.0f;
    
    [Header("Prefabs")]
    public Transform firePoint;
    public GameObject bullet;

    [Header("GameObjects")]
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private GameObject jetPack;
    [SerializeField] private GameObject grenadePoint;

    //RB
    private Rigidbody2D myRb;

    //FLOATS
    private float grenadeSpeed = 2.0f;
    private float jumpForceSpeed = 5.0f;

    //BOOLEANS
    private bool canUseGrenade;
    private bool canUseJetPack;
    private bool canAttack = true;
    private bool isGrounded;

    private bool hasGrenade;
    [SerializeField] private int maxGrenades = 5;
    [SerializeField] private int currentGrenades;

    private Animator animator;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(canUseJetPack)
        {
            UseJetPack();
        }

        //myRb.velocity = new Vector2(5, 0);
    }
    void Start()
    {
        currentGrenades = maxGrenades;

        cooldownTimer = attackCooldown;
        
        //la currentAmmo es igual a la maxAmmo
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            myRb.AddForce(Vector2.up * jumpForceSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetButton("Fire2"))
        {
            canUseJetPack = true;

            animator.SetBool("Jetpack", true);
        }
        if(Input.GetButtonUp("Fire2"))
        {
            canUseJetPack = false;

            animator.SetBool("Jetpack", false);
        }
        
        //restas el time.delta time....
        attackCooldown -= Time.deltaTime;
        
        //...hasta que sea 0
        if (attackCooldown <= 0)
            canAttack = true;
        
        //...ahí disparas::::::::::::::fijate que la currentAmmo sea mayor a 0
        if (Input.GetButtonDown("Fire1") && (canAttack) && (currentAmmo > 0))
        {
            //llamo al metodo de disparar
            Shoot();
            
            //resto 1 a la munición
            currentAmmo -= 1;
            
            //el cooldown timer y attackcooldown se reinician
            cooldownTimer = attackCooldown;
        }
        
        if (currentAmmo <= 0)
            canAttack = false;


        if (Input.GetKeyDown(KeyCode.R) && currentAmmo <= 0)
        {
            Reload();
        }

       
        
        if (Input.GetKeyDown(KeyCode.G) && hasGrenade)
        {
            ShootGrenade();

            currentGrenades -= 1;
        }

        if (currentGrenades <= 0)
            hasGrenade = false;

        

        void Shoot()
        {
           Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        
    }

    private void Reload()
    {
        currentAmmo = maxAmmo;
    }
    
    private void ShootGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, grenadePoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * grenadeSpeed, ForceMode2D.Impulse);

       
    }
    
    private void UseJetPack()
    {
        GameObject jetpack = Instantiate(jetPack, transform.position, Quaternion.identity);
        Rigidbody2D rb2 = jetpack.GetComponent<Rigidbody2D>();
        rb2.AddForce(transform.up * 10, ForceMode2D.Force);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grenade"))
        {
            hasGrenade = true;
        }
    }
}
