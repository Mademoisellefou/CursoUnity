using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Sun : MonoBehaviour
{
    public Light2D _l;
    [SerializeField]
    public float _speedL;
    //ligth will turn:)using UnityEngine.Experimental.Rendering.Universal;
    private void Start()
    {

        StartCoroutine(sunset());
    }
    IEnumerator sunset()
    {
        while (_l.intensity > .5f)
        {
            _l.intensity -= _speedL;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Sunrise());
        StopCoroutine(sunset());
    }
    IEnumerator Sunrise()
    {
        while (_l.intensity < 1f)
        {
            _l.intensity += _speedL;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(sunset());
        StopCoroutine(Sunrise());
    }
}
  