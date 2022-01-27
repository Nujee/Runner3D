using System;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : IDisposable
{
    private ObjectView _player;
    private List<ObjectView> _obstacles;
    private UIView _loseScreen;
    private PickupScoreController _scoreContainer;

    public LoseController(ObjectView player, LevelController levelController, UIView loseScreen, PickupScoreController pickupScoreController)
    {
        _player = player;
        _obstacles = levelController.Levels[levelController.CurrentLevelIndex]._obstacles;
        _loseScreen = loseScreen;
        _scoreContainer = pickupScoreController;

        foreach (ObjectView obstacle in _obstacles)
        {
            obstacle.OnContact += OnShowLoseScreen;
        }
    }

    public void Dispose()
    {
        foreach (ObjectView obstacle in _obstacles)
        {
            obstacle.OnContact -= OnShowLoseScreen;
        }
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
}
