using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController
{
    private List<LevelView> _levels;
    private int _currentLevelIndex;
    private int _finalLevelIndex;

    public List<LevelView> Levels { get => _levels; set => _levels = value; }
    public int CurrentLevelIndex { get => _currentLevelIndex; set => _currentLevelIndex = value; }

    public LevelController (List<LevelView> levels, int startLevelIndex = 2)
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
        LoadLevel(CurrentLevelIndex == _finalLevelIndex ? 0 : CurrentLevelIndex++);
    }

    private void LoadLevel(int levelIndex)
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            if (i == levelIndex)
            {
                Levels[i].IsActive(true);
                foreach (ObjectView pickup in Levels[i]._pickups)
                {
                    pickup.IsInteractive(true);
                }
            }
            else
            {
                Levels[i].IsActive(false);
            }
        }
    }
}
