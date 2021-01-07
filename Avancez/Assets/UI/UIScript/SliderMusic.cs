using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMusic : MonoBehaviour
{
    public AudioSource _audio;
    private float musicV=1f;
    void Start()
    {
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _audio.volume = musicV;
    }
    public void updateV(float vol) {
        musicV=vol;
    }
}
