using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float  movementSpeed = 1f;
    public float distance = 10f;
    public Transform firePoint;
    public GameObject bullet;
    public LayerMask whatIsPlayer;
    public Rigidbody2D rb;
    public Animator animator;
    public float nextShotTime = 0f;
    public float timeBetweenShots = 1.5f;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

       if (Physics2D.Raycast(firePoint.position, firePoint.right, distance, whatIsPlayer))
        {
             if (nextShotTime <= Time.time)
            {
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
