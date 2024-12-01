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
            this.DebugConfig.Force = 100;
        }
    }

    [System.Serializable]
    public class DebugConfig
    {
        public int Force;

    }

}