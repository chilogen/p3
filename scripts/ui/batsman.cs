using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Batsman : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Debug")]
    [Range(-1,1)]public float forceToTorqueRate;
    
    
    [Header("Debug show")]
    [SerializeField]private double torque;


    [Header("Properties")] [Range(0, 10)] 
    public double force;

    private Rigidbody _rigidBodyOfBall;
    private GameObject _activeBall;
    private Transform _transform;

    void Start()
    {
        this._transform = this.GameObject().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.torque = this.force * this.forceToTorqueRate;
        
    }

    private void OnMouseDown()
    {
        Vector3 centerOfBatsman = this._transform.position;
        Vector3 mousePosition = Input.mousePosition;
        Debug.Log(mousePosition);
        Debug.Log(centerOfBatsman);
    }
}
