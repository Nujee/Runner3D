using System;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScoreController : IDisposable
{
    private ObjectView _playerView;
    private List<ObjectView> _pickUpViews;
    private int _score = 0;

    public int Score { get => _score; set => _score = value; }

    public PickUpScoreController (ObjectView playerView, List<ObjectView> pickUpViews)
    {
        _playerView = playerView;
        _pickUpViews = pickUpViews;

        _playerView.OnContact += PickUpScored;
    }

    private void PickUpScored(ObjectView contactView)
    {
        if (_pickUpViews.Contains(contactView))
        {
            Score++;

            var allMeshes = contactView.gameObject.GetComponentsInChildren<MeshRenderer>();
            var collider = contactView._collider;

            allMeshes.MakeInvisible();
            collider.MakeNoninteractive();
        }
    }

    public void Dispose()
    {
        _playerView.OnContact -= PickUpScored;
    }
}
 
