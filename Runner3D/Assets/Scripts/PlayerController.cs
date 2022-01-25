using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private ObjectView _playerView;
    private float _distanceToPlayerBottom;
    private const float _bottomToGroundThreshold = 0.1f;
    private Vector3 _recentPosition;
    private readonly string horizontal = "Horizontal";

    public PlayerController (ObjectView playerView)
    {
        _playerView = playerView;
        _distanceToPlayerBottom = _playerView._collider.bounds.extents.y;
    }

    public void MoveSideways(float horizontalSensitivity, float verticalVelocity)
    {
        _recentPosition = _playerView._transform.position;
        var horizontalVelocity = Input.GetAxis(horizontal) * horizontalSensitivity;
        var movement = new Vector3(horizontalVelocity, 0, verticalVelocity) * Time.deltaTime;
        if (!IsGrounded())
            _playerView._transform.position = _recentPosition;
        _playerView._transform.position += new Vector3(horizontalVelocity, 0, verticalVelocity) * Time.deltaTime;



        //_playerView._rigidbody.MovePosition(currentPosition + movement);
    }

    private bool IsGrounded()
    {
        if (!Physics.Raycast(_playerView._transform.position, -Vector3.up, _distanceToPlayerBottom + _bottomToGroundThreshold))
        {
            Debug.Log("not grounded!");
            return false;
        }
        else
        {
            return true;
        }
    }

}
