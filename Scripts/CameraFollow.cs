
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }
    void Follow() {
        Vector3 targetP = target.position + offset;
        Vector3 smoothP = Vector3.Lerp(transform.position,targetP,smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothP;
    }
}
