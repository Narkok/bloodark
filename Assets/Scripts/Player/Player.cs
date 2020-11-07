using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player: MonoBehaviour
{

    public Health Health;

    private void Start()
    {
        GetComponent<Health>();
    }


    private void OnEnable()
    {
        Health = GetComponent<Health>();

        Health.DeathEvent += OnDeath;
    }


    private void OnDisable()
    {
        Health.DeathEvent -= OnDeath;
    }


    private void Update()
    {
        
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
