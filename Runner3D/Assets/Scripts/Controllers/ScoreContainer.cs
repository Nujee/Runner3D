using System;


namespace Runner3D
{
    public class ScoreContainer
    {
        #region Fields

        private int _pickupValue;

        #endregion

        #region Properties

        public static int Score { get; set; }

        #endregion


        #region Events

        public static event Action OnScoreChanged;

        #endregion

        #region Constructors

        public ScoreContainer(int pickupValue)
        {
            _pickupValue = pickupValue;
            PickupController.OnPickupEarn += delegate () { Score += _pickupValue; };
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            PickupController.OnPickupEarn -= delegate () { Score += _pickupValue; };
        }

        // Wrapping inside public method is because event is
        // to be triggered in another class (PickupController)
        public static void ScoreChanged()
        {
            OnScoreChanged?.Invoke();
        }

        #endregion
    }
}
