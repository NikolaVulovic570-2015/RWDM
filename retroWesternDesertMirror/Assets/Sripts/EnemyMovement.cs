using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float  movementSpeed = 2f;
    //private bool facingLeft = true;
    public bool MoveRight;
    public Rigidbody2D rb;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveRight){
            transform.Translate(2 * Time.deltaTime * movementSpeed, 0,0);
            transform.localScale = new Vector2 (-1.13204f, 1.204392f);
        }
        else 
        {
            transform.Translate(-2 * Time.deltaTime * movementSpeed, 0,0);
            transform.localScale = new Vector2 (1.13204f, 1.204392f);
        }
    }

   void OnTriggerEnter2D(Collider2D trig)
   {
       if (trig.gameObject.CompareTag("turn"))
       {
           if(MoveRight)
           {
               MoveRight = false;
           }
           else
           {
               MoveRight = true;
           }
       }
   }
}
