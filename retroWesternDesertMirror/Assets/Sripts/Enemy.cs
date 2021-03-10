using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float  movementSpeed = 1f;
    public float distance = 10f;
    public Transform firePoint;
    public GameObject bullet;
    public bool isMoving = true;
    public int health = 50;
    public LayerMask whatIsPlayer;
    public Rigidbody2D rb;
    public Animator animator;
    public float nextShotTime = 0f;
    public float timeBetweenShots = 1.5f;
    public AudioSource enemyHit;
    public AudioSource gun;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

        public void takeDamage (int damage)
    {
        enemyHit.Play();
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {

       if (Physics2D.Raycast(firePoint.position, firePoint.right, distance, whatIsPlayer))
        {
             if (nextShotTime <= Time.time)
            {
                gun.Play();
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                animator.SetBool("isFiring", true);
                nextShotTime = Time.time + timeBetweenShots;
            } 

        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * movementSpeed, 0,0);
            animator.SetBool("isFiring", false);
        }
    }

   void OnTriggerEnter2D(Collider2D trig)
   {
       if (trig.gameObject.CompareTag("turn"))
       {
  
           transform.Rotate(0f, 180f,0f);

       }
   }
}
