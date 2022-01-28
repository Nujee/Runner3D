using System;


namespace Runner3D
{
    public class GameScreenController : IDisposable
    {
        #region Fields

        private ObjectView _player;
        private LevelView _currentLevel;
        private UIView _gameScreen;

        #endregion


        #region Constructors

        public GameScreenController(ObjectView player, UIView gameScreen, LevelManager levelManager, int initialScore = 0)
        {
            _player = player;
            _gameScreen = gameScreen;
            _gameScreen._scoreText.text = initialScore.ToString();

            _currentLevel = levelManager.Levels[levelManager.CurrentLevelIndex];

            ScoreContainer.OnScoreChanged += UpdateScore;

            _gameScreen._restartButton.onClick.AddListener(levelManager.RestartLevel);
            _gameScreen._restartButton.onClick.AddListener(SetPlayerToStart);
            _gameScreen._restartButton.onClick.AddListener(ResetScore);
        }

        #endregion


        #region Methods

        public void Dispose()
        {
            ScoreContainer.OnScoreChanged -= UpdateScore;
        }

        private void UpdateScore()
        {
            _gameScreen._scoreText.text = ScoreContainer.Score.ToString();
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

