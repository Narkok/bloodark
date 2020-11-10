using UnityEngine;
using UnityEngine.UI;

public class ZomboHealthBar: MonoBehaviour
{
    [SerializeField]
    private Health _health;

    [SerializeField]
    private float _smoothTime = 5;

    private Slider _healthBar;
    private float _targetHealthValue;


    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
        _targetHealthValue = _healthBar.maxValue;
        _health.ChangeEvent += UpdateHealth;
    }


    private void Update()
    {
        if (_targetHealthValue != _healthBar.value)
            _healthBar.value = Mathf.Lerp(_healthBar.value, _targetHealthValue, _smoothTime * Time.deltaTime);
    }


    public void UpdateHealth(float value)
    {
        _targetHealthValue = value;
    }
}
