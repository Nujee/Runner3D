using UnityEngine;
using UnityEngine.UI;

namespace Runner3D
{
    public class UIView : MonoBehaviour
    {
        #region PublicFields

        public Text _scoreText;
        public Button _restartButton;
        public Button _nextLevelButton;
        public GameObject _activator;

        #endregion


        #region Methods

        public void IsActive(bool isActive)
        {
            _activator.SetActive(isActive);
        }

        #endregion
    }
}
