using UnityEngine;


namespace march3
{
    public class GirdPosition : MonoBehaviour
    {
        private GameObject _son;
        private Rigidbody _son_rb;
        private bool _active_pull;

        public bool Occupy()
        {
            return this._son != null;
        }

        public bool Set(GameObject son)
        {
            if (this._son != null)
            {
                return false;
            }

            this._son = son;
            this._son_rb = this._son.GetComponent<Rigidbody>();
            son.transform.SetParent(this.transform);
            return true;
        }

        public GameObject DestroySon()
        {
            GameObject obj = this._son;
            this._son = null;
            this._son_rb = null;
            this._active_pull = false;
            obj.transform.position = new Vector3(10000, 10000, 10000);
            obj.SetActive(false);
            return this._son;
        }

        public void Update()
        {
            if (!this._active_pull)
            {
                return;
            }

            Vector3 forceDirection = this.transform.position - this._son.transform.position;
            this._son_rb.AddForce(forceDirection);
            if (forceDirection.magnitude < 1f)
            {
                this._active_pull = false;
                this._son_rb.transform.position = this.transform.position;
                this._son_rb.velocity = Vector3.zero;
                this._son_rb.angularVelocity = Vector3.zero;
            }
        }

        public void Pull()
        {
            this._active_pull = true;
        }
    }
}
