using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float xInput;
    public float jumpForce = 1f;
    private bool facingRight = true;
    public float movementSpeed = 4f;
    public int health = 100;
    public Transform reflectionPoint;
    public GameObject reflection;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource playerHit;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void takeDamage (int damage)
    {
        playerHit.Play ();
        health -= damage;
        if (health == 65)
        {
            Destroy(life1);
        }

        if (health == 30)
        {
            Destroy(life2);
        }

        if (health <= 0)
        {
            Destroy(life3);
            SceneManager.LoadScene("GameOver");
        }
    }

    void Update()
    {
        var xInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(xInput));
        transform.Translate(xInput * Time.deltaTime * movementSpeed, 0,0);
      

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

       if (Mathf.Abs(rb.velocity.y) > 0.001f)
        {
            animator.SetBool("isJumping", true);
        }

        else {
            animator.SetBool("isJumping", false);
        }

            if (xInput > 0 && !facingRight)
			{
				Flip();
			}
			else if (xInput < 0 && facingRight)
			{
				Flip();
			}

        if (Input.GetKeyDown(KeyCode.S))
        {
           Instantiate(reflection, reflectionPoint.position, reflectionPoint.rotation); 
           animator.SetBool("isReflecting", true);
        }      

        if (Input.GetKeyUp(KeyCode.S))
        {
           animator.SetBool("isReflecting", false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Tnx");
        }
    
    }

     void OnTriggerEnter2D (Collider2D hit)
     {
         if (hit.gameObject.tag.Equals("EndGame"))
         {
             SceneManager.LoadScene("EndGame");
         }
     }

    	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    
}


