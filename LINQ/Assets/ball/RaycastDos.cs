using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDos : MonoBehaviour
{
    // Detecta todos  objetos a  la izquierda 
    Transform PuntoPosi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] _hit;
        _hit = Physics.RaycastAll(PuntoPosi.position,PuntoPosi.right,100.0f);
        for (var i = 0; i < _hit.Length; i++) {
            RaycastHit hit = _hit[i];
            bool gun = hit.collider.GetComponent<Renderer>();
            var rend = GetComponent<Renderer>();
            if (gun) {
                hit.collider.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Difusse");
                rend.material.color=Color.green;

            }

        }
            
    }
}
