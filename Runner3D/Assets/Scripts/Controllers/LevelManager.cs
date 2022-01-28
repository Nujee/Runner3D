using System;
using System.Collections.Generic;


namespace Runner3D
{
    public class LevelManager
    {
        #region Fields

        private List<LevelView> _levels;
        private int _currentLevelIndex;
        private int _finalLevelIndex;

        #endregion


        #region Properties

        public List<LevelView> Levels { get => _levels; set => _levels = value; }

        public int CurrentLevelIndex
        {
            get => _currentLevelIndex;
            set => _currentLevelIndex = value > _finalLevelIndex ? 0 : value;
        }

        #endregion


        #region Events

        public Action OnNextLevel { get; set; }

        #endregion


        #region Constructors

        public LevelManager(List<LevelView> levels, int startLevelIndex = 0)
        {
            Levels = levels;
            _finalLevelIndex = levels.Count - 1;
            CurrentLevelIndex = startLevelIndex;

            LoadLevel(CurrentLevelIndex);
        }

        #endregion


        #region Methods

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
                }
                else
                {
                    Levels[i].IsActive(false);
                }
            }
        }

        #endregion
    }

}
