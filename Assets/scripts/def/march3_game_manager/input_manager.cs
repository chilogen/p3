using UnityEngine;
using System;

namespace march3
{
    public static class InputManager
    {
        private static event Action OnLaunch;
        private static Vector3 _startPos, _endPos;
        private static DateTime _startTime, _endTime;


        public static Vector3 GetDragDirection()
        {
            var dragVector = _endPos - _startPos;
            dragVector.z = dragVector.y;
            dragVector.y = 0;
            
            // dragVector = new Vector3(100, 0, 0);
            
            // dragVector =Config.Instance.DebugConfig.maxForwardForce/ Mathf.Max(dragVector.magnitude,Config.Instance.DebugConfig.maxForwardForce) * dragVector;
            var upwardForce = Config.Instance.DebugConfig.maxUpwardForce * (Mathf.Min(Config.Instance.DebugConfig.maxHoldMillSeconds,(float)_endTime.Subtract(_startTime).TotalMilliseconds)/Config.Instance.DebugConfig.maxHoldMillSeconds);
            // dragVector.y = upwardForce;
            
            var worldForceDirection = Camera.main.transform.TransformDirection(dragVector);
            worldForceDirection = Config.Instance.DebugConfig.maxForwardForce /
                                  Mathf.Max(worldForceDirection.magnitude,
                                      Config.Instance.DebugConfig.maxForwardForce) *
                                  worldForceDirection;
            
            worldForceDirection.y = -upwardForce;
            // worldForceDirection.Normalize();
            
            worldForceDirection.y = -worldForceDirection.y;
            Debug.Log(worldForceDirection);
            return worldForceDirection;
        }

        public static void SetStart(Vector3 position)
        {
            _startPos = position;
            _startTime = DateTime.Now;
        }

        public static void SetEnd(Vector3 position)
        {
            _endPos = position;
            _endTime = DateTime.Now;
        }

        public static void RegisterLaunchHandler(Action action)
        {
            OnLaunch += action;
        }

        public static void Launch()
        {
            OnLaunch?.Invoke();
        }
    }
}