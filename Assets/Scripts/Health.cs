using UnityEngine;
using System;

public class Health: MonoBehaviour
{

    public event Action DeathEvent;
    public event Action<float> ChangeEvent;

    [SerializeField]
    private float _hp = 40;

    [SerializeField]
    private float _maxHP = 40;


    public void TakeDamage(float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, _maxHP);
        if (_hp <= 0) DeathEvent?.Invoke();
        ChangeEvent?.Invoke(_hp / _maxHP);
    }
}
