using UnityEngine;


namespace march3
{
    public class GridPoint : MonoBehaviour
    {
        private PieBall _son;
        private bool _activePull;

        public PieBall Occupy()
        {
            return this._son;
        }

        public void SwapSon(GridPoint other)
        {
            var tmp = this._son;
            this.SetSon(other.Occupy());
            other.RemoveSon();
            other.SetSon(tmp);
        }

        public bool SetSon(PieBall son)
        {
            if (!object.ReferenceEquals(_son,null)||object.ReferenceEquals(son,null))
            {
                return false;
            }

            this._son = son;
            son.transform.SetParent(this.transform);
            son.transform.localPosition = new Vector3(0, -2, 0);
            return true;
        }

        public void RemoveSon()
        {
            this._son = null;
        }

        public GameObject DestroySon()
        {
            GameObject obj = this._son.Get();
            this._son = null;
            this._activePull = false;
            obj.transform.position = new Vector3(10000, 10000, 10000);
            obj.SetActive(false);
            return this._son.Get();
        }

        public void Update()
        {
            if (!this._activePull)
            {
                return;
            }

            Vector3 forceDirection = this.transform.position - this._son.transform.position;
            this._son.GetRigidbody().AddForce(forceDirection);
            if (forceDirection.magnitude < 1f)
            {
                this._activePull = false;
                this._son.GetRigidbody().transform.position = this.transform.position;
                this._son.GetRigidbody().velocity = Vector3.zero;
                this._son.GetRigidbody().angularVelocity = Vector3.zero;
            }
        }

        public void Pull()
        {
            this._activePull = true;
        }
    }
}
