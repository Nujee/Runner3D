using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private ObjectView _playerView;
    private readonly string horizontal = "Horizontal";

    public PlayerController (ObjectView playerView)
    {
        _playerView = playerView;
    }

    public void MoveSideways(float horizontalSensitivity, float verticalVelocity)
    {
        var horizontalVelocity = Input.GetAxis(horizontal) * horizontalSensitivity;
        var movement = new Vector3(horizontalVelocity, 0, verticalVelocity) * Time.deltaTime;
        var currentPosition = _playerView._transform.position;

        _playerView._rigidbody.MovePosition(currentPosition + movement);
    }
}
