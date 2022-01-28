using System;
using UnityEngine;


namespace Runner3D
{
    public class LoseController : LevelResultController, IDisposable
    {
        #region Fields
        
        private ObjectView _player;
        private LevelView _currentLevel;
        private LevelManager _levelManager;
        private UIView _loseScreen;
        
        #endregion


        #region Constructors

        public LoseController(UIView loseScreen, ObjectView player, LevelManager levelManager)
        {
            _loseScreen = loseScreen;
            _player = player;
            _levelManager = levelManager;
            _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];

            _player.OnContact += OnShowLoseScreen;

            foreach (ObjectView obstacle in _currentLevel._obstacles)
            {
                _levelManager.OnNextLevel += OnSetNextLevelObstacles;
            }

            _loseScreen._restartButton.onClick.AddListener(delegate { base.HideScreen(_loseScreen); });
            _loseScreen._restartButton.onClick.AddListener(_levelManager.RestartLevel);
            _loseScreen._restartButton.onClick.AddListener(delegate { base.SetPlayerToStart(_player, _currentLevel); });
            _loseScreen._restartButton.onClick.AddListener(base.ResetScore);
        }

        #endregion


        #region Methods

        public void Dispose()
        {
            foreach (ObjectView obstacle in _currentLevel._obstacles)
            {
                obstacle.OnContact -= OnShowLoseScreen;
            }
        }

        private void OnShowLoseScreen(ObjectView contactObject)
        {
            if (_currentLevel._obstacles.Contains(contactObject))
            {
                base.ShowScreen(_loseScreen);
            }
        }
        
        // This methods updates _currentLevel (increased by 1) since OnNextLevel callback. Otherwise Player will only be
        // interactable with previous level's objects, which are obviously inactive by then
        private void OnSetNextLevelObstacles()
        {
            _currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
        }

        #endregion
    }
}
