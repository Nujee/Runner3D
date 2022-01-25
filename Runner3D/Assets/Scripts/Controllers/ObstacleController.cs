using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : IDisposable
{
    private ObjectView _playerView;
    private List<ObjectView> _obstacleViews;

    public ObstacleController(ObjectView playerView, List<ObjectView> obstacleViews)
    {
        _playerView = playerView;
        _obstacleViews = obstacleViews;

        _playerView.OnContact += ObstacleLose;
    }

    private void ObstacleLose(ObjectView contactView)
    {
        if (_obstacleViews.Contains(contactView))
        {

        }
    }

    public void Dispose()
    {

    }
}
