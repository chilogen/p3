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
            return _endPos - _startPos;
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