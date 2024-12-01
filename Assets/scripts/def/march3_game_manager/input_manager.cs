using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;

namespace march3
{
    public static class InputManager
    {
        private static event Action OnLaunch;
        private static Vector3 _startPos, _endPos;


        public static Vector3 GetDragDirection()
        {
            var dragVector = _endPos - _startPos;
            var forceDirection = new Vector3(dragVector.x, 0, dragVector.y).normalized;
            var worldForceDirection = Camera.main.transform.TransformDirection(forceDirection);
            worldForceDirection.y = 0;
            worldForceDirection.Normalize();
            return worldForceDirection;
        }

        public static void SetStart(Vector3 position)
        {
            _startPos = position;
        }

        public static void SetEnd(Vector3 position)
        {
            _endPos = position;
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