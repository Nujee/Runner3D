using System;
using UnityEngine;

public class WinController : IDisposable
{
    private ObjectView _player;
    private ObjectView _finish;
    private UIView _winScreen;
    private PickupScoreController _scoreContainer;
    
    public WinController(ObjectView player, LevelController levelController, UIView winScreen,  PickupScoreController pickupScoreController)
    {

        _player = player;
        _finish = levelController.Levels[levelController.CurrentLevelIndex]._finish;
        _winScreen = winScreen;
        _scoreContainer = pickupScoreController;

        _finish.OnContact += OnShowWinScreen;
    }

    public void Dispose()
    {
        _finish.OnContact -= OnShowWinScreen;
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
        _winScreen._scoreText.text = "You won! Your total score is " + _scoreContainer.Score.ToString();
    }
}
