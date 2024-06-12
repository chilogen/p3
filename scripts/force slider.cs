using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forceslider : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider forceSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(forceSlider.value);
    }
}
