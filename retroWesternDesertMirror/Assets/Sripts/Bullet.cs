using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg = 35;
    public float speed = 12f;
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
             enemy.takeDamage(dmg);
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
             player.takeDamage(dmg);
             Destroy(gameObject);
         }

         Boss boss = hit.GetComponent<Boss>();
         if (boss != null)
         {
             boss.takeDamage(dmg);
             Destroy(gameObject);
         }
     }
}
