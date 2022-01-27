using System;
using UnityEngine;

public class WinController : IDisposable
{
    private ObjectView _player;
    private LevelView _currentLevel;
    private LevelController _levelController;
    private UIView _winScreen;
    private PickupScoreController _scoreContainer;

    public WinController(ObjectView player, LevelController levelController, UIView winScreen,  PickupScoreController pickupScoreController)
    {
        _player = player;
        _levelController = levelController;
        _currentLevel = _levelController.Levels[_levelController.CurrentLevelIndex];
        _winScreen = winScreen;
        _scoreContainer = pickupScoreController;

        _player.OnContact += OnShowWinScreen;
        _levelController.OnNextLevel += OnSetNextLevelFinish;

        _winScreen._nextLevelButton.onClick.AddListener(HideWinScreen);
        _winScreen._nextLevelButton.onClick.AddListener(levelController.MoveToNextLevel);
        _winScreen._nextLevelButton.onClick.AddListener(SetPlayerToStart);
        _winScreen._nextLevelButton.onClick.AddListener(ResetScore);

        _winScreen._nextLevelButton.onClick.AddListener(OnSetNextLevelFinish);
    }

    public void Dispose()
    {
        _currentLevel._finish.OnContact -= OnShowWinScreen;
        _levelController.OnNextLevel -= OnSetNextLevelFinish;
    }

    private void OnShowWinScreen(ObjectView contactObject)
    {
        if (contactObject == _currentLevel._finish)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        Time.timeScale = 0;
        _winScreen.IsActive(true);
        _winScreen._scoreText.text = _scoreContainer.Score.ToString();
    }

    private void OnSetNextLevelFinish()
    {
        _currentLevel = _levelController.Levels[_levelController.CurrentLevelIndex];
    }

    private void HideWinScreen()
    {
        Time.timeScale = 1;
        _winScreen.IsActive(false);
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
