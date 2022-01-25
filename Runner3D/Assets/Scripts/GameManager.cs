using System.Collections.Generic;
using UnityEngine;

class GameManager : MonoBehaviour
{
    [SerializeField] private ObjectView _playerView;
    [SerializeField] private List<LevelView> _levelViews;

    [Header("Player characteristics")]
    [Range(0, 25)]
    [SerializeField] private float _horizontalSensitivity = 5f;
    [Range(0, 25)]
    [SerializeField] private float _verticalVelocity = 5f;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = new PlayerController(_playerView);
    }

    private void FixedUpdate()
    {
        _playerController.Move(_horizontalSensitivity, _verticalVelocity);
    }
}
