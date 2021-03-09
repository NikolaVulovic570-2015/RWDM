using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D (Collider2D hit)

     {
         Enemy enemy = hit.GetComponent<Enemy>();
         if (enemy != null)
         {
             Destroy(gameObject);
         }

        if (hit.gameObject.tag.Equals("reflection"))
        {
            rb.velocity = -transform.right * speed;
            transform.Rotate(0f, 180f,0f);
        }

        Player player = hit.GetComponent<Player>();
         if (player != null)
         {
             player.takeDamage(35);
             Destroy(gameObject);
         }
     }
}
