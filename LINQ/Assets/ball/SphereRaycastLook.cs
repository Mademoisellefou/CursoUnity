
using UnityEngine;

public class SphereRaycastLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {
        RaycastHit hit;
        var controll = GetComponent<CharacterController>();
        var  p1 =controll.transform.position+transform.position;
        if (Physics.SphereCast(p1, controll.height / 2, Vector3.right, out hit, 1000f)) {
            print("Maybe this worh");
        }
    }
}
