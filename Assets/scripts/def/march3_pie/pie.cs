using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace march3
{
    public class PieBall : MonoBehaviour
    {

        private string _tag;
        private int _score;
        private List<string> _tags = new List<string> { "Red", "Blue", "Yellow", "Green", "Purple" };
        private List<int> _scores = new List<int> { 1, 2, 4, 8, 16 };
        private Rigidbody _rigidbody;


        public void Init(string tag = "random", int score = -1)
        {
            this._tag = tag != "random" ? tag : this._tags[UnityEngine.Random.Range(0, this._tags.Count)];
            this._score = score != -1 ? score : this._scores[UnityEngine.Random.Range(0, _scores.Count)];
            if (ReferenceEquals(_rigidbody, null))
            {
                this._rigidbody = this.GetComponent<Rigidbody>();
            }
        }

        public GameObject Get()
        {
            return this.gameObject;
        }

        public string GetTag()
        {
            return this._tag;
        }

        public int GetScore()
        {
            return this._score;
        }

        public Rigidbody GetRigidbody()
        {
            return this._rigidbody;
        }

        // Start is called before the first frame update
        void Start()
        {
            this._rigidbody = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
