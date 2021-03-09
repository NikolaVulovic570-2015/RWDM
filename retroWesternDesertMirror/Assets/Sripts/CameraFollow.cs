using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Range(1,10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    
    void Follow()
    {
        Vector3 targetPosition = new Vector3(target.position.x + 5f,0,-10);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
