using System;
using UnityEngine;

public class WinScreenController : IDisposable
{
    private ObjectView _player;
    private UIView _winScreen;
    private LevelView _currentLevel;
    private PickupScoreController _pickupScoreController;
    
    public WinScreenController(UIView winScreen, LevelController levelController, ObjectView player, PickupScoreController pickupScoreController)
    {
        _winScreen = winScreen;
        _currentLevel = levelController.Levels[levelController.CurrentLevelIndex];
        _player = player;
        _pickupScoreController = pickupScoreController;

        _currentLevel._finish.OnContact += OnShowWinScreen;
    }

    public void Dispose()
    {
        _currentLevel._finish.OnContact -= OnShowWinScreen;
    }

    private void OnShowWinScreen(ObjectView contactObject)
    {
        if (contactObject == _player)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        Time.timeScale = 0;
        _winScreen.IsActive(true);
        _winScreen._scoreText.text = "You won! Your total score is " + _pickupScoreController.Score.ToString();
    }
}
