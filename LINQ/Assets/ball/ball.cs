
using UnityEngine;
enum estados { ataca1,ataca2,ataca3}
       
public class ball : MonoBehaviour
{
    Vector3 _Speed, rot;
    Rigidbody _rigidbody;
    estados est;
    int cont = 0;
    private void Start()
    {
        est = estados.ataca1;

        _Speed = new Vector3(0, 3, 0); rot = new Vector3(0, 100, 0);
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A))cont++;
        switch (cont) {
            case 1:
                est = estados.ataca1;
              
                break;
            case 2:
                est = estados.ataca2;
                var tiempo = Quaternion.Euler(rot * Time.deltaTime);
                _rigidbody.MoveRotation(_rigidbody.rotation * tiempo);
                break;
            default:
                break;
               
        }
        switch (est)
        {
            case estados.ataca1:
               
                _rigidbody.MovePosition(_rigidbody.position + _Speed * Time.deltaTime);
                break;
            case estados.ataca2:
                
                var tiempo = Quaternion.Euler(rot * Time.deltaTime);
                _rigidbody.MoveRotation(_rigidbody.rotation * tiempo);
                break;


        }
    }

}
