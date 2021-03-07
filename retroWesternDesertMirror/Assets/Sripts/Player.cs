using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xInput;
    public float jumpForce = 1f;
    private bool facingRight = true;
    public float movementSpeed = 4f;
    public Rigidbody2D rb;
    public Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        var xInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(xInput));

        transform.position += new Vector3(xInput,0,0) * Time.deltaTime * movementSpeed;

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

    }

    void FixedUpdate(){

        
    }

    	private void Flip()
	{

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    
}


