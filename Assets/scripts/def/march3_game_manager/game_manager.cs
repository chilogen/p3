using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace march3
{
    public class game_manager : MonoBehaviour
    {
    
        public GirdManager GirdManager;
        
        private List<string> _tags = new List<string>{"Red", "Blue", "Yellow", "Green", "Purple"};
        private List<int> _scores = new List<int>{1,2,4,8,16};
        private PieObjPool _piePool = new PieObjPool();
    
        void Start()
        {
            StartCoroutine(ScheduleWorker());
        }
    
        IEnumerator ScheduleWorker()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                worker();
            }
        }
    
        void worker()
        {
            this.GirdManager.Next();
            PieBall newPie = _piePool.Get();
            newPie.GetRigidbody().AddForce(new Vector3(0, 0, 0), ForceMode.VelocityChange);
        }
    
        void OnCollider(PieBall move)
        {
            Vector2 gridPosition = this.GirdManager.NearestGrid(move.Get().transform);
            GirdPosition gird = this.GirdManager.Set(move.Get(), gridPosition);
            gird.Pull();
        }
    }
}


