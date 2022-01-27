using System.Collections.Generic;
using UnityEngine;

class GameManager : MonoBehaviour
{
    private int curLevInd = 0;

    [SerializeField] private ObjectView _playerView;
    [SerializeField] private List<LevelView> _levelViews;
    [SerializeField] private UIView _gameScreenView;
    [SerializeField] private UIView _winScreenView;
    [SerializeField] private UIView _loseScreenView;

    [Header("Player characteristics")]
    [Range(0, 25)]
    [SerializeField] private float _horizontalSensitivity = 5f;
    [Range(0, 25)]
    [SerializeField] private float _verticalVelocity = 5f;

    private PlayerController _playerController;
    private PickUpScoreController _pickUpScoreController;
    private GameScreenController _gameScreenController;
    private LevelController _levelController;

    private void Start()
    {
        _playerController = new PlayerController(_playerView);
        _levelController = new LevelController(_levelViews);
        _pickUpScoreController = new PickUpScoreController(_playerView, _levelController);
        _gameScreenController = new GameScreenController(_gameScreenView, _pickUpScoreController);
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
