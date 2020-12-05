using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Weapon: MonoBehaviour
{
    [SerializeField]
    private float _damage = 10;
    public float Damage { get { return _damage; } }

    private Collider _collider;


    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }


    public void ActivateCollider()
    {
        _collider.enabled = true;
    }


    public void DeactivateCollider()
    {
        _collider.enabled = false;
    }
}
