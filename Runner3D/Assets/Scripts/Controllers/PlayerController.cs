using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private ObjectView _playerView;
    private readonly string horizontal = "Horizontal";
    private float _horizontalSensitivity;
    private float _verticalVelocity;

    public PlayerController (ObjectView playerView, float horizontalSensitivity, float verticalVelocity)
    {
        _playerView = playerView;
        _horizontalSensitivity = horizontalSensitivity;
        _verticalVelocity = verticalVelocity;
    }

    public void Move(float horizontalSensitivity, float verticalVelocity)
    {
        var horizontalVelocity = Input.GetAxis(horizontal) * horizontalSensitivity;
        var movement = new Vector3(horizontalVelocity, 0, verticalVelocity) * Time.deltaTime;
        var currentPosition = _playerView._transform.position;

        _playerView._rigidbody.MovePosition(currentPosition + movement);
    }
}
