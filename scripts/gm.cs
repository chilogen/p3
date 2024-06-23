using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject _activateBall;

    [Header("Debug")] 
    public GameObject activateBall;

    public void SetActivateBall()
    {
        
    }
    void Awake()
    {
        Instance = this;
    }

    public void FireBall()
    {
        if (_activateBall == null){
            //Debug.Log("There is Not Activate Ball");
            //return;
            this._activateBall = this.activateBall;
        }

        Ball fireFunc = (Ball)this._activateBall.GetComponent(typeof(Ball));
        
        
        fireFunc.Fire(ForceSlider.Instance.GetValue());
    }
}