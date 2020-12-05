using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damagable: MonoBehaviour
{
    private Health _health;


    private void Awake()
    {
        _health = GetComponent<Health>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Weapon>(out Weapon weapon))
            _health.TakeDamage(weapon.Damage);
    }
}
