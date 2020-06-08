using UnityEngine;

public class InputMouse : MonoBehaviour
{
    float HorizontalSpeed = 2.0f;
    float VerticalSpeed = 2.0f;


    void Start()
    {
        
    }

   
    void Update()
    {
        float _h = Input.GetAxis("Mouse X") * HorizontalSpeed;
        float _v = Input.GetAxis("Mouse Y") * VerticalSpeed;
        transform.Rotate(_h,_v,0);
    }
}
