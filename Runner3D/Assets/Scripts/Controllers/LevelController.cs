using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController
{
    private List<LevelView> _levelViews;
    private int _currentLevelIndex = 0;
    private int _finalLevelIndex;

    public int CurrentLevelIndex { get => _currentLevelIndex; set => _currentLevelIndex = value; }

    public LevelController (List<LevelView> levelViews)
    {
        _levelViews = levelViews;
        _finalLevelIndex = levelViews.Count - 1;
    }

    private void RestartLevel(int currentLevelIndex)
    {
        LoadLevel(currentLevelIndex);
    }

    private void MoveToNextLevel(int currentLevelIndex)
    {
        LoadLevel(currentLevelIndex == _finalLevelIndex ? 0 : currentLevelIndex++);
    }

    private void LoadLevel(int levelIndex)
    {
        for (int i = 0; i < _levelViews.Count; i++)
        {
            if (i == levelIndex)
            {
                _levelViews[i].IsActive(true);
                foreach (ObjectView pickUpView in _levelViews[i]._pickUpViews)
                {
                    pickUpView.IsInteractive(true);
                }
            }
            else
            {
                _levelViews[i].IsActive(false);
            }
        }
    }
}
