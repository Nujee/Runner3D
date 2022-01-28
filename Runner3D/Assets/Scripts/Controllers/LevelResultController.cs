using UnityEngine;


namespace Runner3D
{
    public class LevelResultController
    {
        #region Methods

        protected void ShowScreen(UIView uiView)
        {
            Time.timeScale = 0;
            uiView.IsActive(true);
            uiView._scoreText.text = ScoreContainer.Score.ToString();
        }

        protected void HideScreen(UIView uiView)
        {
            Time.timeScale = 1;
            uiView.IsActive(false);
        }

        protected void SetPlayerToStart(ObjectView player, LevelView currentLevel)
        {
            player._transform.position = currentLevel._startPosition.position;
        }

        protected void ResetScore()
        {
            ScoreContainer.Score = 0;
            ScoreContainer.ScoreChanged();
        }

        #endregion
    }
}

