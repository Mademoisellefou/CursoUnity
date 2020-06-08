using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    float speedbullet =500f;
    public Transform projectile;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            var clone = Instantiate(projectile,transform.position,Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce (-transform.forward
             *speedbullet);
        }    
    }
}
