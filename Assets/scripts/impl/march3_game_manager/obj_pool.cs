using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


namespace march3
{

    public class PieObjPool
    {
        private ObjectPool<PieBall> _pool;
        public static readonly PieObjPool Instance = new ();

        public void Init()
        {
            var prefab = Resources.Load ("march3/pie");
            if (prefab == null)
            {
                Debug.LogError ("march3/pie prefab not found");
                return;
            }

            _pool = new ObjectPool<PieBall>(
                createFunc: ()=>Object.Instantiate(prefab).GetComponent<PieBall>(),
                actionOnGet: obj=>obj.gameObject.SetActive(true),
                actionOnRelease:obj=>obj.gameObject.SetActive(false),
                actionOnDestroy:obj=>Object.Destroy(obj.gameObject));
        }
        public PieBall Get(Vector3? position)
        {
            var ball = _pool.Get();
            ball.Init();
            if (position != null)
            {
                ball.transform.position = position.Value;
            }

            return ball;
        }

        public void Return(PieBall obj)
        {
            this._pool.Release(obj);
        }
    }

}