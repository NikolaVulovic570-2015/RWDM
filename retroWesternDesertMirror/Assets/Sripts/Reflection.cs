using UnityEngine;

public class Reflection : MonoBehaviour
{  
    public float movementSpeed = 4f;
    GameObject reflectionPoint;

    void Update()
    {
        reflectionPoint = GameObject.Find("ReflectionPoint");
        if(gameObject != null)
        {
            Destroy(gameObject, 0.6f);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {  
            Destroy(gameObject);
        }

        Vector3 targetPosition = new Vector3(reflectionPoint.transform.position.x, reflectionPoint.transform.position.y, -1);
        transform.position = targetPosition;
    }
}
