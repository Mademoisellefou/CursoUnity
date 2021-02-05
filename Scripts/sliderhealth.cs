using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderhealth : MonoBehaviour
{

    public Slider slider;
    private void Awake()
    {
        slider.value = slider.maxValue;
    }
    public void step()
    {
        if (slider.value <= 0) return;
        slider.value -=1;
    }
}
