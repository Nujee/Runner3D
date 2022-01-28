using System;
using UnityEngine;


namespace Runner3D
{
    public class ObjectView : MonoBehaviour
    {
        #region PublicFields

        public Transform _transform;
        public Collider _collider;
        public Rigidbody _rigidbody;

        #endregion


        #region Events

        public Action<ObjectView> OnContact { get; set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            if (gameObject.GetComponent<Transform>())
                _transform = gameObject.GetComponent<Transform>();

            if (gameObject.GetComponent<Collider>())
                _collider = gameObject.GetComponent<Collider>();

            if (gameObject.GetComponent<Rigidbody>())
                _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            ObjectView temp = other.gameObject.GetComponent<ObjectView>();
            OnContact?.Invoke(temp);
        }

        #endregion
    }
}
