using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xInput, yInput;
    private bool isMoving;
    public float speed = 4f;
    public Rigidbody2D rb;
    public Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;    
    }

    // Update is called once per frame
    void Update()
    {

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        isMoving = (xInput != 0 || yInput != 0);

        if (isMoving)
        {
             var moveVector = new Vector3(xInput, yInput, 0);
             rb.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime),
            (transform.position.y + moveVector.y * speed * Time.deltaTime)));
            animator.SetFloat("Speed", xInput);
        }
    }
    
}


