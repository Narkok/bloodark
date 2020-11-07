using UnityEngine;

public class Health: MonoBehaviour
{

    public delegate void OnDeathDelegate();
    public event OnDeathDelegate DeathEvent;

    public delegate void OnChangeDelegate(float value);
    public event OnChangeDelegate ChangeEvent;

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
