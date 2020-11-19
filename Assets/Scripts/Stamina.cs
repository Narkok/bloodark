using UnityEngine;
using System;
using System.Collections;

public class Stamina: MonoBehaviour
{

    public event Action<float> ChangeEvent;

    public float Value { get { return _stamina; } }

    [SerializeField]
    private float _stamina = 100;

    [SerializeField]
    private float _maxStamina = 100;

    [SerializeField]
    private float _increaseSpeed = 5;
    private float _currentIncreaseSpeed = 0;

    [SerializeField]
    private float _increaseDelayTime = 2;


    private Coroutine _increaseDelayCoroutine;


    public void Decrease(float value)
    {
        _stamina = Mathf.Clamp(_stamina - value, 0, _maxStamina);
        ChangeEvent?.Invoke(_stamina / _maxStamina);
        RestartIncreaseTimer();
    }


    private void Update()
    {
        if ((_currentIncreaseSpeed != 0) && (_stamina < _maxStamina))
        {
            _stamina = Mathf.Clamp(_stamina + _increaseSpeed * Time.deltaTime, 0, _maxStamina);
            ChangeEvent?.Invoke(_stamina / _maxStamina);
        }
    }


    private void RestartIncreaseTimer()
    {
        if (_increaseDelayCoroutine != null)
        {
            StopCoroutine(_increaseDelayCoroutine);
            _increaseDelayCoroutine = null;
        }
        _currentIncreaseSpeed = 0;
        _increaseDelayCoroutine = StartCoroutine(ResetIncreaseSpeed());
    }


    private IEnumerator ResetIncreaseSpeed()
    {
        yield return new WaitForSeconds(_increaseDelayTime);
        _currentIncreaseSpeed = _increaseSpeed;
    }
}