using System.Collections.Generic;
using UnityEngine;

namespace Runner3D
{
    class GameManager : MonoBehaviour
    {
        #region SerializableFields

        [SerializeField] private ObjectView _player;
        [SerializeField] private List<LevelView> _levels;
        [SerializeField] private UIView _gameScreen;
        [SerializeField] private UIView _winScreen;
        [SerializeField] private UIView _loseScreen;

        [Header("Customizables")]
        [Range(0, 25)]
        [SerializeField] private float _horizontalSensitivity = 5f;
        [Range(0, 25)]
        [SerializeField] private float _verticalVelocity = 5f;
        [SerializeField] private int _pickupValue;

        #endregion

        #region ControllerFields

        private LevelManager _levelManager;
        private PlayerController _playerController;
        private PickupController _pickupController;
        private ScoreContainer _scoreContainer;
        private GameScreenController _gameScreenController;
        private WinController _winController;
        private LoseController _loseController;

        #endregion

        private void Start()
        {
            _levelManager = new LevelManager(_levels);
            _playerController = new PlayerController(_player, _horizontalSensitivity, _verticalVelocity);
            _scoreContainer = new ScoreContainer(_pickupValue);
            _pickupController = new PickupController(_player, _levelManager);
            _gameScreenController = new GameScreenController(_player, _gameScreen, _levelManager);
            _winController = new WinController(_winScreen, _player, _levelManager);
            _loseController = new LoseController(_loseScreen, _player, _levelManager);
        }

        private void FixedUpdate()
        {
            _playerController.Move(_horizontalSensitivity, _verticalVelocity);
        }
    }
}
