using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseController : IDisposable 
{
    private ObjectView _player;
    private LevelView _currentLevel;
    private LevelManager _levelManager;
    private UIView _loseScreen;
    private ScoreContainer _scoreContainer;

    public LoseController(ObjectView player, LevelManager levelManager, UIView loseScreen, ScoreContainer scoreContainer)
    {
        _player = player;
        _levelManager = levelManager;
        _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
        _loseScreen = loseScreen;
        _scoreContainer = scoreContainer;

        _player.OnContact += OnShowLoseScreen;

        foreach (ObjectView obstacle in _currentLevel._obstacles)
        {
            _levelManager.OnNextLevel += OnSetNextLevelObstacles;
        }

        _loseScreen._restartButton.onClick.AddListener(HideLoseScreen);
        _loseScreen._restartButton.onClick.AddListener(_levelManager.RestartLevel);
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

    // Updates _currentLevel (increased by 1) since OnNextLevel callback. Otherwise Player will only be
    // interactable with previous level's objects, which are obviously inactive by then
    private void OnSetNextLevelObstacles()
    {
        _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
    }

    private void OnShowLoseScreen(ObjectView contactObject)
    {
        if (_currentLevel._obstacles.Contains(contactObject))
        {
            ShowLoseScreen();
        }
    }

    private void ShowLoseScreen()
    {
        Time.timeScale = 0;
        _loseScreen.IsActive(true);
        _loseScreen._scoreText.text = _scoreContainer.Score.ToString();
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
