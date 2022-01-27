using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenController
{
    private UIView _gameScreenView;
    private PickUpScoreController _pickUpScoreController;
    private LevelView _currentLevelView;

    public GameScreenController (UIView gameScreenView, PickUpScoreController pickUpScoreController)
    {
        _gameScreenView = gameScreenView;
        _pickUpScoreController = pickUpScoreController;
    }

    public void Update()
    {
        _gameScreenView._scoreText.text = "Your score: " + _pickUpScoreController.Score.ToString();
    }
}
