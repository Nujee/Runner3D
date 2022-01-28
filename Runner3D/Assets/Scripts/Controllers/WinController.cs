using System;
using UnityEngine;


namespace Runner3D
{
    public class WinController : LevelResultController, IDisposable
    {
        #region Fields

        private ObjectView _player;
        private LevelView _currentLevel;
        private LevelManager _levelManager;
        private UIView _winScreen;

        #endregion


        #region Constructors

        public WinController(UIView winScreen, ObjectView player, LevelManager levelManager)
        {
            _winScreen = winScreen;
            _player = player;
            _levelManager = levelManager;
            _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
            

            _player.OnContact += OnShowWinScreen;
            _levelManager.OnNextLevel += OnSetNextLevelFinish;

            _winScreen._nextLevelButton.onClick.AddListener(delegate { base.HideScreen(_winScreen); });
            _winScreen._nextLevelButton.onClick.AddListener(levelManager.MoveToNextLevel);
            _winScreen._nextLevelButton.onClick.AddListener(delegate { base.SetPlayerToStart(_player, _currentLevel); });
            _winScreen._nextLevelButton.onClick.AddListener(base.ResetScore);

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
                base.ShowScreen(_winScreen);
            }
        }

        private void ShowWinScreen()
        {
            Time.timeScale = 0;
            _winScreen.IsActive(true);
            _winScreen._scoreText.text = ScoreContainer.Score.ToString();
        }

        // This methods updates _currentLevel (increased by 1) since OnNextLevel callback. Otherwise Player will only be
        // interactable with previous level's objects, which are obviously inactive by then
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
            ScoreContainer.Score = 0;
            ScoreContainer.ScoreChanged();
        }

        #endregion
    }
}
