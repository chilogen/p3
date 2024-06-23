using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
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

        RoundBall fireFunc = (RoundBall)this._activateBall.GetComponent(typeof(RoundBall));
        
        
        fireFunc.Fire(ForceSlider.Instance.GetValue(),Vector2.zero);
    }
}
