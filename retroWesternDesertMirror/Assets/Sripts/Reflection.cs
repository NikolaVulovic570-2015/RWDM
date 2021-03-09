using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public float movementSpeed = 4f;

    void Start()
    {
       
    }

    void Update()
    {
        if(gameObject != null)
        {
            Destroy(gameObject, 0.3f);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {  
            Destroy(gameObject);
        }

        var xInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(xInput * Time.deltaTime * movementSpeed, 0,0);
      
   
     

    }
  
}
