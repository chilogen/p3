using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace march3
{
    public class GameManager : MonoBehaviour
    {
        
        void Start()
        {
            GirdManager.Instance.Init();
            PieObjPool.Instance.Init();
            PieLauncher.Instance.Start(this.transform.position);
            InputManager.RegisterLaunchHandler(HandleLaunch);
            
            StartCoroutine(ScheduleWorker());
        }
    
        IEnumerator ScheduleWorker()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                GirdManager.Instance.Next();
            }
        }

        private static void HandleLaunch()
        {
            var forceDirection = InputManager.GetDragDirection();
            PieLauncher.Instance.Launch(forceDirection, 1.1f);
        }

    
        void OnCollider(PieBall move)
        {
            Vector2 gridPosition = GirdManager.Instance.NearestGrid(move.Get().transform);
            // GridPoint gird = GirdManager.Set(move.Get(), gridPosition);
            // gird.Pull();
        }
    }
}


