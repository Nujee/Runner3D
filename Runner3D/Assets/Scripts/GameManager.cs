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
    private WinController _winController;
    private LoseController _loseController;

    private void Start()
    {
        _playerController = new PlayerController(_player);
        _levelController = new LevelController(_levels);
        _pickupScoreController = new PickupScoreController(_player, _levelController);
        _gameScreenController = new GameScreenController(_gameScreen, _pickupScoreController);
        _winController = new WinController(_player, _levelController, _winScreen, _pickupScoreController);
        _loseController = new LoseController(_player, _levelController, _loseScreen, _pickupScoreController);
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
