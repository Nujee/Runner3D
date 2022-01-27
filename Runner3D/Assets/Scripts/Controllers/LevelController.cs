using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController
{
    private List<LevelView> _levelViews;
    private int _currentLevelIndex;
    private int _finalLevelIndex;

    public List<LevelView> LevelViews { get => _levelViews; set => _levelViews = value; }
    public int CurrentLevelIndex { get => _currentLevelIndex; set => _currentLevelIndex = value; }

    public LevelController (List<LevelView> levelViews, int startLevelIndex = 2)
    {
        LevelViews = levelViews;
        _finalLevelIndex = levelViews.Count - 1;
        CurrentLevelIndex = startLevelIndex;

        LoadLevel(CurrentLevelIndex);
    }

    public void RestartLevel()
    {
        LoadLevel(CurrentLevelIndex);
    }

    public void MoveToNextLevel()
    {
        LoadLevel(CurrentLevelIndex == _finalLevelIndex ? 0 : CurrentLevelIndex++);
    }

    private void LoadLevel(int levelIndex)
    {
        for (int i = 0; i < LevelViews.Count; i++)
        {
            if (i == levelIndex)
            {
                LevelViews[i].IsActive(true);
                foreach (ObjectView pickUpView in LevelViews[i]._pickUpViews)
                {
                    pickUpView.IsInteractive(true);
                }
            }
            else
            {
                LevelViews[i].IsActive(false);
            }
        }
    }
}
