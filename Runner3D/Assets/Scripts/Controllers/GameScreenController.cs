using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenController
{
    private UIView _gameScreen;
    private PickupScoreController _pickupScoreController;
    private LevelView _currentLevel;

    public GameScreenController (UIView gameScreen, PickupScoreController pickupScoreController)
    {
        _gameScreen = gameScreen;
        _pickupScoreController = pickupScoreController;
    }

    public void Update()
    {
        _gameScreen._scoreText.text = _pickupScoreController.Score.ToString();
    }
}
