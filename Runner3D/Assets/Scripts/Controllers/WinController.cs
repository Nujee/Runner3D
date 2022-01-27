using System;
using UnityEngine;

public class WinController : IDisposable
{
    #region Fields

    private ObjectView _player;
    private LevelView _currentLevel;
    private LevelManager _levelManager;
    private UIView _winScreen;
    private ScoreContainer _scoreContainer;

    #endregion


    #region Constructors

    public WinController(ObjectView player, LevelManager levelManager, UIView winScreen, ScoreContainer scoreContainer)
    {
        _player = player;
        _levelManager = levelManager;
        _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
        _winScreen = winScreen;
        _scoreContainer = scoreContainer;

        _player.OnContact += OnShowWinScreen;
        _levelManager.OnNextLevel += OnSetNextLevelFinish;

        _winScreen._nextLevelButton.onClick.AddListener(HideWinScreen);
        _winScreen._nextLevelButton.onClick.AddListener(levelManager.MoveToNextLevel);
        _winScreen._nextLevelButton.onClick.AddListener(SetPlayerToStart);
        _winScreen._nextLevelButton.onClick.AddListener(ResetScore);

        _winScreen._nextLevelButton.onClick.AddListener(OnSetNextLevelFinish);
    }

    #endregion


    #region Methods

    public void Dispose()
    {
        _currentLevel._finish.OnContact -= OnShowWinScreen;
        _levelManager.OnNextLevel -= OnSetNextLevelFinish;
    }

    private void OnShowWinScreen(ObjectView contactObject)
    {
        if (contactObject == _currentLevel._finish)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        Time.timeScale = 0;
        _winScreen.IsActive(true);
        _winScreen._scoreText.text = _scoreContainer.Score.ToString();
    }
    // Updates _currentLevel (increased by 1) since OnNextLevel callback
    // If not doing so, Player will only be interactable with previous level'
    // objects, which are obviously inactive by then
    private void OnSetNextLevelFinish()
    {
        _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
    }

    private void HideWinScreen()
    {
        Time.timeScale = 1;
        _winScreen.IsActive(false);
    }

    private void SetPlayerToStart()
    {
        _player._transform.position = _currentLevel._startPosition.position;
    }

    private void ResetScore()
    {
       _scoreContainer.Score = 0;
    }

    #endregion
}
