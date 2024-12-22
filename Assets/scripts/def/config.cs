using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace march3
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configurations/GameConfig")]
    public class Config : ScriptableObject
    {

        private static Config _Instance;

        public static Config Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = Resources.Load<Config>("Config");
                }
                return _Instance;
            }
        }
        public DebugConfig DebugConfig;

        private void OnEnable()
        {
            this.DebugConfig = new();
        }
    }

    [System.Serializable]
    public class DebugConfig
    {
        public float pieRotateSpeed;
        public float maxHoldMillSeconds;
        public float maxForwardForce;
        public float maxUpwardForce;
    }

}