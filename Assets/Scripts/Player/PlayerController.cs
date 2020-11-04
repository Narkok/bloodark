using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private CharacterController _controller;
    private Transform _mainCamera;
    private Transform _transform;

    [Header("Movement")]
    [SerializeField]
    private float WalkSpeed = 2;
    [SerializeField]
    private float RunSpeed = 5;
    private float currentSpeed = 0;
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;


    //[Space(10)]
    [Header("HP")]
    [SerializeField]
    private float _hp = Constants.Game.PlayerHP;
    public float HP { get { return _hp; } }

    [Header("Stamina")]
    [SerializeField]
    private float _stamina = Constants.Game.PlayerStamina;
    public float Stamina { get { return _stamina; } }

    [SerializeField]
    [InspectorName("Value")]
    private float _increaseSpeed = 5;

    [SerializeField]
    private float _decreaseSpeed = 10;

    [SerializeField]
    private bool isRunning = false;


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        /// Исправить поиск камеры
        _mainCamera = GameObject.Find("Main Camera").transform;
        _transform = transform;

        currentSpeed = WalkSpeed;
    }


    private void Update()
    {
        UpdateCurrentSpeed();

        float horizontal = Input.GetAxisRaw(Constants.Axis.Horizontal);
        float vertical = Input.GetAxisRaw(Constants.Axis.Vertical);
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            _transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }

        _controller.Move(Vector3.down * Time.deltaTime * 8);

        UpdateStamina();
    }


    private void UpdateCurrentSpeed()
    {
        isRunning = Input.GetAxisRaw(Constants.Axis.Run) > 0.5;
        if (_stamina <= 0) { isRunning = false; }
        currentSpeed = isRunning ? RunSpeed : WalkSpeed;
    }


    private void UpdateStamina()
    {
        if (isRunning)
        {
            _stamina = Mathf.Clamp(_stamina - Time.deltaTime * _decreaseSpeed, 0, Constants.Game.PlayerStamina);
            Managers.instance.UI.UpdateStamina(_stamina);
        }
        else
        {
            _stamina = Mathf.Clamp(_stamina + Time.deltaTime * _increaseSpeed, 0, Constants.Game.PlayerStamina);
            Managers.instance.UI.UpdateStamina(_stamina);
        }
    }


    public void GetDamage(float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, Constants.Game.PlayerHP);
        Managers.instance.UI.UpdateHealth(_hp);
        if (_hp <= 0) Die();
    }


    private void Die()
    {
        Debug.Log("You Died");
        // Тут потом анмацию смерти надо запустить
        // И меню открыть
    }
}