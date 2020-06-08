using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed =10f;
    float rotationSpeed =100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _traslate = Input.GetAxis("Vertical")* speed;
        float  _rotation = Input.GetAxis("Horizontal")*rotationSpeed;
        _traslate *=Time.deltaTime;
        _rotation *=Time.deltaTime;
        transform.Translate(0,0,_traslate);
        transform.Rotate(0, _rotation, 0);
    }
}
