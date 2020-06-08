using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastUno : MonoBehaviour
{
    public Transform Punto;
    void Start()
    {
        
    }

  
    void Update()
    {
        Vector3 _forward = Punto.TransformDirection(Vector3.forward);
        if (Physics.Raycast(Punto.position, _forward, 100)) {
            print("collision");
        }
    }
}
