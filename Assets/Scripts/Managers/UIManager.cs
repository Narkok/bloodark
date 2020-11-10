using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Player _player;


    private void Awake()
    {
        _targetHealthValue = 1;
        _targetStaminaValue = 1;
    }


    public void ConnectPlayer(Player player)
    {
        _player = player;
        _player.Health.ChangeEvent += UpdateHealth;
    }


    private void OnDisable()
    {
        if (_player == null) return;
        _player.Health.ChangeEvent -= UpdateHealth;
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
