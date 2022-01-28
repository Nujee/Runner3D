using System.Collections.Generic;
using UnityEngine;


namespace Runner3D
{
    public class LevelView : MonoBehaviour
    {
        #region PublicFields

        public GameObject _activator;
        public List<ObjectView> _obstacles;
        public List<ObjectView> _pickups;
        public Transform _startPosition;
        public ObjectView _finish;

        #endregion


        #region Methods

        public void IsActive(bool isActive)
        {
            _activator.SetActive(isActive);
        }

        #endregion
    }
}

