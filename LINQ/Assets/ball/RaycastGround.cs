using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaycastGround : MonoBehaviour
{
    public  Transform pies;
    void Start()
    {
        
    }
    void Update()
    {
        var _up =transform.TransformDirection(Vector3.up);
        RaycastHit  hit;
        GameObject _name;
        Debug.DrawRay(transform.position, -_up * 5f, Color.green);
        if (Physics.Raycast(transform.position, -_up * Time.deltaTime * 0.001f,out hit, 1f)) {
            if (hit.collider.gameObject.name == "Plane") {
                _name = GameObject.Find("Plane");
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
         
}
}