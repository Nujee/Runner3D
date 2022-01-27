using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseController : IDisposable
{
    private ObjectView _player;
    private LevelView _currentLevel;
    private LevelController _levelController;
    private UIView _loseScreen;
    private PickupScoreController _scoreContainer;

    public LoseController(ObjectView player, LevelController levelController, UIView loseScreen, PickupScoreController pickupScoreController)
    {
        _player = player;
        _levelController = levelController;
        _currentLevel = _levelController.Levels[_levelController.CurrentLevelIndex];
        _loseScreen = loseScreen;
        _scoreContainer = pickupScoreController;

        foreach (ObjectView obstacle in _currentLevel._obstacles)
        {
            _levelController.OnNextLevel += OnSetNextLevelObstacles;
            obstacle.OnContact += OnShowLoseScreen;
        }

        _loseScreen._restartButton.onClick.AddListener(HideLoseScreen);
        _loseScreen._restartButton.onClick.AddListener(_levelController.RestartLevel);
        _loseScreen._restartButton.onClick.AddListener(SetPlayerToStart);
        _loseScreen._restartButton.onClick.AddListener(ResetScore);
    }

    public void Dispose()
    {
        foreach (ObjectView obstacle in _currentLevel._obstacles)
        {
            obstacle.OnContact -= OnShowLoseScreen;
        }
    }

    private void OnSetNextLevelObstacles()
    {
        _currentLevel = _levelController.Levels[_levelController.CurrentLevelIndex];
    }

    private void OnShowLoseScreen(ObjectView contactObject)
    {
        if (contactObject == _player)
        {
            ShowLoseScreen();
        }
    }

    private void ShowLoseScreen()
    {
        Time.timeScale = 0;
        _loseScreen.IsActive(true);
        _loseScreen._scoreText.text = "You lose! Your total score is " + _scoreContainer.Score.ToString();
    }

    private void HideLoseScreen()
    {
        Time.timeScale = 1;
        _loseScreen.IsActive(false);
    }

    private void SetPlayerToStart()
    {
        _player._transform.position = _currentLevel._startPosition.position;
    }

    private void ResetScore()
    {
        _scoreContainer.Score = 0;
    }
}
