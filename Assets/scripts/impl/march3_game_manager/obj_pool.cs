using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Pool;


namespace march3
{

    public class PieObjPool
    {
        private ObjectPool<PieBall> _pool;
        private PieBall _prefab;

        public PieObjPool()
        {
            _prefab = Resources.Load ("march3/pie") as PieBall;
            if (_prefab == null)
            {
                Debug.LogError ("march3/pie prefab not found");
            }

            _pool = new ObjectPool<PieBall>(
                createFunc: ()=>Object.Instantiate(_prefab),
                actionOnGet: obj=>obj.gameObject.SetActive(true),
                actionOnRelease:obj=>obj.gameObject.SetActive(false),
                actionOnDestroy:obj=>Object.Destroy(obj.gameObject));
        }
        public PieBall Get()
        {
            return _pool.Get();
        }

        public void Return(PieBall obj)
        {
            this._pool.Release(obj);
        }
    }

}