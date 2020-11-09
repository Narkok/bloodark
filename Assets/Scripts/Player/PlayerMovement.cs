﻿using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private CharacterController _controller;
    private Transform _mainCamera;
    private Transform _transform;

    [Header("Movement")]
    [SerializeField]
    private float _walkSpeed = 2;
    [SerializeField]
    private float _runSpeed = 3.5f;
    private float _currentSpeed = 0;
    [SerializeField]
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    [SerializeField]
    private float _gravity = 8;

    [Header("Stamina")]
    [SerializeField]
    private float _stamina = Constants.Game.PlayerStamina;
    public float Stamina { get { return _stamina; } }

    [SerializeField]
    [InspectorName("Value")]
    private float _increaseSpeed = 5;

    [SerializeField]
    private float _decreaseSpeed = 10;

    private bool _isRunning = false;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _mainCamera = Camera.main.transform;
        _transform = transform;
        _currentSpeed = _walkSpeed;
    }


    private void Update()
    {
        UpdateCurrentSpeed();

        float horizontal = 0;//Input.GetAxis(Constants.Axis.Horizontal);
        float vertical = 0;//Input.GetAxis(Constants.Axis.Vertical);
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        float magnitude = Mathf.Clamp(direction.magnitude, -1, 1);

        if (magnitude >=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            _transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized * magnitude * _currentSpeed * Time.deltaTime);
        }

        _controller.Move(Vector3.down * Time.deltaTime * _gravity);

        UpdateStamina();
    }


    private void UpdateCurrentSpeed()
    {
        _isRunning = false;//Input.GetAxisRaw(Constants.Axis.Run) > 0.5;
        if (_stamina <= 0.1) { _isRunning = false; }
        _currentSpeed = _isRunning ? _runSpeed : _walkSpeed;
    }


    private void UpdateStamina()
    {
        if (_isRunning)
        {
            _stamina = Mathf.Clamp(_stamina - Time.deltaTime * _decreaseSpeed, 0, Constants.Game.PlayerStamina);
            Game.instance.UI.UpdateStamina(_stamina);
        }
        else
        {
            _stamina = Mathf.Clamp(_stamina + Time.deltaTime * _increaseSpeed, 0, Constants.Game.PlayerStamina);
            Game.instance.UI.UpdateStamina(_stamina);
        }
    }
}