using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private CharacterController _controller;
    private Transform _mainCamera;
    private Transform _transform;

    public float WalkSpeed = 2;
    public float RunSpeed = 5;
    private float currentSpeed = 0;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;


    public int HP { get { return _hp; } }
    [SerializeField]
    private int _hp = Constants.Game.PlayerHP;


    public int Stamina { get { return _stamina; } }
    [SerializeField]
    private int _stamina = Constants.Game.PlayerStamina;


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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
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
    }


    public void GetDamage(int damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, Constants.Game.PlayerHP);
        if (_hp <= 0) Die();
    }


    private void Die()
    {
        Debug.Log("You Died");
        // Тут потом анмацию смерти надо запустить
        // И меню открыть
    }
}