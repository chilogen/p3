using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

namespace march3
{
    public class PieLauncher
    {
        public static readonly PieLauncher Instance = new();
        
        private Vector3 _startPos;
        private PieBall _bullet;

        public void Start(Vector3 pos)
        {
            this._startPos = pos;
            this._bullet = PieObjPool.Instance.Get(_startPos);
        }

        public PieBall Launch(Vector3 direction, float force)
        {
            if (this._bullet == null)
            {
                Debug.Log("call init before using launcher");
                return null;
            }

            var rb = this._bullet.GetRigidbody();
            if (rb == null)
            {
                Debug.Log("Cannot launch because no bullet attached");
                return null;
            }
            rb.AddForce(direction * 10);
            var obj = this._bullet;
            this._bullet = PieObjPool.Instance.Get(_startPos);
            return obj;
        }
    }
}