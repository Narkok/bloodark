using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Stamina))]
public class Player: MonoBehaviour
{

    public Health Health;
    public Stamina Stamina;


    private void Awake()
    {
        Health = GetComponent<Health>();
        Stamina = GetComponent<Stamina>();
    }


    private void OnEnable()
    {
        Health.DeathEvent += OnDeath;
    }


    private void OnDisable()
    {
        Health.DeathEvent -= OnDeath;
    }


    public void GetDamage(float damage)
    {
        Health.TakeDamage(damage);
    }


    private void OnDeath()
    {
        Debug.Log("DIED");
    }
}
