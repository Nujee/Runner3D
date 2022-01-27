using System;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScoreController : IDisposable
{
    private ObjectView _playerView;
    private LevelController _levelController;
    private List<ObjectView> _pickUpViews;
    private int _score = 0;

    public int Score { get => _score; set => _score = value; }

    public PickUpScoreController (ObjectView playerView, LevelController levelController)
    {
        _playerView = playerView;
        _pickUpViews = levelController.LevelViews[levelController.CurrentLevelIndex]._pickUpViews;

        _playerView.OnContact += OnPickup;
    }

    private void OnPickup(ObjectView contactView)
    {
        if (_pickUpViews.Contains(contactView))
        {
            Score++;
            contactView.IsInteractive(false);
        }
    }

    public void Dispose()
    {
        _playerView.OnContact -= OnPickup;
    }

    //private void OnScoreChanged
}
 
