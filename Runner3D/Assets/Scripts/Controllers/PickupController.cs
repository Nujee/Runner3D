using System;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : IDisposable
{
    #region Fields

    private ObjectView _player;
    private LevelManager _levelManager;
    private LevelView _currentLevel;

    #endregion


    #region EventHandlers

    public static event Action OnPickupEarn;

    #endregion


    #region Constructors

    public PickupController (ObjectView player, LevelManager levelManager)
    {
        _player = player;
        _levelManager = levelManager;
        _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];

        _levelManager.OnNextLevel += SetNextLevelPickups;
        _player.OnContact += PickUp;
    }

    #endregion 


    #region Methods

    public void Dispose()
    {
        _player.OnContact -= PickUp;
        _levelManager.OnNextLevel -= SetNextLevelPickups;
    }

    // Updates _currentLevel (increased by 1) since OnNextLevel callback. Otherwise Player will only be
    // interactable with previous level's objects, which are obviously inactive by then
    private void SetNextLevelPickups()
    {
        _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
    }

    private void PickUp(ObjectView contactObject)
    {
        if (_currentLevel._pickups.Contains(contactObject))
        {
            OnPickupEarn?.Invoke();
            contactObject.gameObject.SetActive(false);
        }
    }

    #endregion
}

