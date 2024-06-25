using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace obj
{


    public enum PoleType
    {
        North,
        South
    }

    public class Magnet : MonoBehaviour
    {
        public bool fixedObject;
        public PoleType pole;

        [Header("Only Available when \"Fixed Object\" is True")]
        [Range(1, 10)] public float forceRate = 1;

        public AnimationCurve forceCurve;

        private Transform _selfTransform;
        private float _maxDistance = 1;

        public void Awake()
        {
            if (!this.fixedObject)
            {
                return;
            }

            SphereCollider col = (SphereCollider)this.GetComponent<Collider>();
            this._selfTransform = this.GetComponent<Transform>();
        }

        public PoleType GetPoleType()
        {
            return this.pole;
        }

        public void OnTriggerStay(Collider other)
        {
            if (!this.fixedObject)
            {
                return;
            }

            Magnet otherScript = other.GetComponent<Magnet>();
            if (otherScript == null)
            {
                return;
            }
            Rigidbody otherRigbody = other.GetComponent<Rigidbody>();

            Transform otherTransform = other.GetComponent<Transform>();

            Vector3 forceDirection = this._selfTransform.position - otherTransform.position;
            float distance = (this._selfTransform.position - otherTransform.position).magnitude;
            if (distance > this._maxDistance)
            {
                this._maxDistance = distance;
                Debug.Log(distance);
            }

            Vector3 force = this.GetForce(distance) * forceDirection;

            if (this.GetPoleType() == otherScript.GetPoleType())
            {
                force *= -1;
            }
            
            otherRigbody.AddForceAtPosition(force,otherTransform.position);
        }


        public float GetForce(float distance)
        {
            float x = distance / this._maxDistance;
            return this.forceRate * forceCurve.Evaluate(x);
        }
    }
}