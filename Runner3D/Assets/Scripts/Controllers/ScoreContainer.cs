using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreContainer
{
    public int Score { get; set; }

    public ScoreContainer(int pickupValue)
    {
        PickupController.OnPickupEarn += delegate () { Score += pickupValue; }; 
    }
}
