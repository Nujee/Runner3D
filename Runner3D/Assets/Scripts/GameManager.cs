using System.Collections.Generic;
using UnityEngine;

class GameManager : MonoBehaviour
{
    [SerializeField] private ObjectView _player;
    [SerializeField] private List<LevelView> _levels;
    [SerializeField] private UIView _gameScreen;
    [SerializeField] private UIView _winScreen;
    [SerializeField] private UIView _loseScreen;

    [Header("Player characteristics")]
    [Range(0, 25)]
    [SerializeField] private float _horizontalSensitivity = 5f;
    [Range(0, 25)]
    [SerializeField] private float _verticalVelocity = 5f;

    private PlayerController _playerController;
    private PickupScoreController _pickupScoreController;
    private GameScreenController _gameScreenController;
    private LevelController _levelController;
    private WinScreenController _winScreenController;

    private void Start()
    {
        _playerController = new PlayerController(_player);
        _levelController = new LevelController(_levels);
        _pickupScoreController = new PickupScoreController(_player, _levelController);
        _gameScreenController = new GameScreenController(_gameScreen, _pickupScoreController);
        _winScreenController = new WinScreenController(_winScreen, _levelController, _player, _pickupScoreController);
    }
    
    private void Update()
    {
        _gameScreenController.Update();
    }

    private void FixedUpdate()
    {
        _playerController.Move(_horizontalSensitivity, _verticalVelocity);
    }
}
