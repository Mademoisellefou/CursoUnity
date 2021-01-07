using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firtsperson : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    public float rotX;
    
    void Update()
    {
        MouseAiming();
        KeyboardMovement();
    }
    public void MouseAiming()
    {
        //Input 
        var inX = Input.GetAxis("Mouse X")*2f;
        var iny = Input.GetAxis("Mouse Y")*2f;
        transform.localEulerAngles = new Vector3(0,iny,0);
        Camera.main.transform.localEulerAngles = new Vector3(inX,iny,0);
    }
   public void KeyboardMovement() {
        Vector3 dir = new Vector3(0,0,0);
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        transform.Translate(dir,Space.World);
    
    }
}
