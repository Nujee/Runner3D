using System;
using System.Collections.Generic;
using UnityEngine;

public class PickupScoreController : IDisposable
{
    private ObjectView _player;
    private LevelController _levelController;
    private LevelView _currentLevel;
    private int _score = 0;

    public int Score { get => _score; set => _score = value; }

    public PickupScoreController (ObjectView player, LevelController levelController)
    {
        _player = player;
        _levelController = levelController;
        _currentLevel = _levelController.Levels[_levelController.CurrentLevelIndex];

        _levelController.OnNextLevel += SetNextLevelPickups;
        _player.OnContact += PickUp;
    }

    public void Dispose()
    {
        _player.OnContact -= PickUp;
        _levelController.OnNextLevel -= SetNextLevelPickups;
    }

    private void SetNextLevelPickups()
    {
        _currentLevel = _levelController.Levels[_levelController.CurrentLevelIndex];
    }

    private void PickUp(ObjectView contactObject)
    {
        if (_currentLevel._pickups.Contains(contactObject))
        {
            Score++;
            contactObject.gameObject.SetActive(false);
            //contactObject.IsInteractive(false);
        }
    }


}
 
