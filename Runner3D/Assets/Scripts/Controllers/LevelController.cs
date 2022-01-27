using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController
{
    private List<LevelView> _levels;
    private int _currentLevelIndex;
    private int _finalLevelIndex;

    public List<LevelView> Levels { get => _levels; set => _levels = value; }

    public int CurrentLevelIndex 
    { 
        get => _currentLevelIndex; 
        set => _currentLevelIndex = value > _finalLevelIndex ? 0 : value; 
    }

    public Action OnNextLevel { get; set; }

    public LevelController (List<LevelView> levels, int startLevelIndex = 1)
    {
        Levels = levels;
        _finalLevelIndex = levels.Count - 1;
        CurrentLevelIndex = startLevelIndex;

        LoadLevel(CurrentLevelIndex);
    }

    public void RestartLevel()
    {
        LoadLevel(CurrentLevelIndex);
    }

    public void MoveToNextLevel()
    {
        CurrentLevelIndex++;
        OnNextLevel?.Invoke();
        LoadLevel(CurrentLevelIndex);
    }

    private void LoadLevel(int levelIndex)
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            if (i == levelIndex)
            {
                Levels[i].IsActive(true);
                foreach (ObjectView pickup in Levels[i]._pickups)
                    pickup.gameObject.SetActive(true);
                    //pickup.IsInteractive(true);
            }
            else
            {
                Levels[i].IsActive(false);
            }
        }
    }
}
