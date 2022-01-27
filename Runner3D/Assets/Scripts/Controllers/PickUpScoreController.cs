using System;
using System.Collections.Generic;
using UnityEngine;

public class PickupScoreController : IDisposable
{
    private ObjectView _player;
    private List<ObjectView> _pickups;
    private int _score = 0;

    public int Score { get => _score; set => _score = value; }

    public PickupScoreController (ObjectView player, LevelController levelController)
    {
        _player = player;
        _pickups = levelController.Levels[levelController.CurrentLevelIndex]._pickups;

        _player.OnContact += OnPickup;
    }


    private void OnPickup(ObjectView contactObject)
    {
        if (_pickups.Contains(contactObject))
        {
            Score++;
            contactObject.IsInteractive(false);
        }
    }

    public void Dispose()
    {
        _player.OnContact -= OnPickup;
    }

    //private void OnScoreChanged
}
 
