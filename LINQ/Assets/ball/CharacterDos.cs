

using UnityEngine;

public class CharacterDos : MonoBehaviour
{
    private float speed=3.0f;
    private float rotateSpeed = 3.0f;
    void Start()
    {
        
    }

    void Update()
    {
        var controll = GetComponent<CharacterController>();
        transform.Rotate(0,Input.GetAxis("Horizontal")*rotateSpeed,0);
        var _forward =transform.TransformDirection(Vector3.forward);
        float  current =speed*Input.GetAxis("Vertical") ;
        controll.Move(current* _forward);
        
    }
}
