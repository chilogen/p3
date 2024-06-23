using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseBall : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Transform _transform;

    //will replace when introduce cinemalmachine
    private Transform _cameraTransform;

    private void Awake()
    {
        this._rigidbody = this.GetComponent<Rigidbody>();
        this._transform = this.GetComponent<Transform>();
        this._cameraTransform = Camera.main.GetComponent<Transform>();
    }

    public void Fire(float force, Vector2 aimPosition)
    {
        Vector3 forceDirection = this._transform.position - this._cameraTransform.position;
        this._rigidbody.AddForceAtPosition(force * forceDirection, this.GetForcePosition(aimPosition,this._transform),
            ForceMode.Impulse);
    }
    

    protected virtual Vector3 GetForcePosition(Vector2 aimPosition, Transform ball)
    {
        throw new NotImplementedException();
    }
}

public class PieBall : BaseBall
{
    protected override Vector3 GetForcePosition(Vector2 aimPosition,Transform ball)
    {
        return Vector3.zero;
    }
}