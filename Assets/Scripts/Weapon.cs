using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Weapon: MonoBehaviour
{

    private Collider _collider;


    private void Awake()
    {
        _collider = GetComponent<Collider>();
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
