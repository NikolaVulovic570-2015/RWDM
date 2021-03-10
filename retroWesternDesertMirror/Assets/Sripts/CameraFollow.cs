using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Range(1,10)]
    public float smoothFactor;
    public float direction;

    private void FixedUpdate()
    {
        Follow();
    }

    
    void Follow()
    {
        if (target.localScale.x < 0f)
        {
           direction = -5f;
        }  
        if (target.localScale.x > 0f)
        {
           direction = 5f;
        }        

        Vector3 targetPosition = new Vector3(target.position.x + direction,0,-10);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
