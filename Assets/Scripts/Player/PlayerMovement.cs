using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement: MonoBehaviour
{
    private CharacterController _controller;
    private Transform _mainCamera;
    private Stamina _stamina;
    private Transform _transform;
    private PlayerInput _input;
    private PlayerAnimator _playerAnimator;

    [Header("Movement")]
    [SerializeField]
    private float _walkSpeed = 1.4f;
    [SerializeField]
    private float _runSpeed = 3.4f;
    private float _currentSpeed = 0;
    [SerializeField]
    private float _turnSmoothTime = 0.15f;
    private float _turnSmoothVelocity;

    [Header("Running")]
    [SerializeField]
    private float _staminaForRun = 0.06f;
    private bool _isRunning = false;

    [Space]
    [SerializeField]
    private float _gravity = 8;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _stamina = GetComponent<Stamina>();
        _mainCamera = Camera.main.transform;
        _playerAnimator = GetComponent<PlayerAnimator>();
        _transform = transform;
        _currentSpeed = _walkSpeed;
        _input = new PlayerInput();
    }


    private void OnEnable()
    {
        _input.Enable();
    }


    private void OnDisable()
    {
        _input.Disable();
    }


    private void Update()
    {
        UpdateCurrentSpeed();
        Vector2 inputDir = _input.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputDir.x, 0f, inputDir.y);
        float magnitude = Mathf.Clamp(direction.magnitude, -1, 1);
        

        if (magnitude >=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            _playerAnimator.TurnAmount = angle - _transform.rotation.eulerAngles.y;
            _transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = moveDir.normalized * magnitude * _currentSpeed;
            _playerAnimator.ForwardAmount = moveDir.magnitude;
            _controller.Move(moveDir * Time.deltaTime);
        } else
        {
            _playerAnimator.ForwardAmount = 0;
            _playerAnimator.TurnAmount = 0;
        }

        _controller.Move(Vector3.down * Time.deltaTime * _gravity);
    }


    private void UpdateCurrentSpeed()
    {
        _isRunning = _input.Player.Run.ReadValue<float>() > 0.5;
        if (_isRunning) _stamina.Decrease(_staminaForRun);
        if (_stamina.Value <= 0.1) { _isRunning = false; }
        _currentSpeed = _isRunning ? _runSpeed : _walkSpeed;
    }
}