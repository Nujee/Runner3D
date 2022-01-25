using UnityEngine;

class GameManager : MonoBehaviour
{
    [SerializeField] private ObjectView _playerView;

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

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        _playerController.MoveSideways(_horizontalSensitivity, _verticalVelocity);
    }
}
