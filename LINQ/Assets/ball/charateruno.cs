
using UnityEngine;

public class charateruno : MonoBehaviour
{
    private float _speed;
    public float  jumpspeed=8.0f;
    public float graV=20f;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        _speed = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var controll =GetComponent<CharacterController>();
        if (controll.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.z*=_speed;
        
        if (Input.GetButton("Jump")) {
            moveDirection.y = jumpspeed;
        }
        }
        moveDirection.y -= graV * Time.deltaTime;
        controll.Move(moveDirection*Time.deltaTime);
    }
}
