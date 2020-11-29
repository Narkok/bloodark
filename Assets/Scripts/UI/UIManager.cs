using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UIManager: MonoBehaviour
{
    [SerializeField]
    private float _smoothTime = 5;

    [SerializeField]
    private Slider _healthBar;
    private float _targetHealthValue;

    [SerializeField]
    private Slider _staminaBar;
    private float _targetStaminaValue;

    [SerializeField]
    private Frame _frame;

    private Player _player;

    private RectTransform _transform;


    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _targetHealthValue = 1;
        _targetStaminaValue = 1;
        _frame.gameObject.SetActive(true);
    }


    public void ConnectPlayer(Player player)
    {
        _player = player;
        _player.Health.ChangeEvent += UpdateHealth;
        _player.Stamina.ChangeEvent += UpdateStamina;
    }


    private void OnDisable()
    {
        if (_player == null) return;
        _player.Health.ChangeEvent -= UpdateHealth;
        _player.Stamina.ChangeEvent -= UpdateStamina;
    }


    private void Update()
    {
        float t = _smoothTime * Time.deltaTime;
        if (_targetHealthValue != _healthBar.value)
        {
            _healthBar.value = Mathf.Lerp(_healthBar.value, _targetHealthValue, t);
        }

        if (_targetStaminaValue != _staminaBar.value)
        {
            _staminaBar.value = Mathf.Lerp(_staminaBar.value, _targetStaminaValue, t);
        }

        _frame.Scale = _transform.localScale.x;
    }


    private void UpdateHealth(float value)
    {
        _targetHealthValue = value;
    }


    public void UpdateStamina(float value)
    {
        _targetStaminaValue = value;
    }
}
