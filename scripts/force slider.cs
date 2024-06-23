using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceSlider : MonoBehaviour
{
    public static ForceSlider Instance;
    
    private const float MaxForce = 10;
    public Slider slider;
    void Awake()
    {
        Instance = this;
        slider.maxValue = MaxForce;
    }

    public float GetValue()
    {
        return this.slider.value;
    }
}
