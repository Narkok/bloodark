using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerAttack : MonoBehaviour
{
    private Stamina _stamina;
    private PlayerInput _input;
    private PlayerAnimator _playerAnimator;


    private void Awake()
    {
        _stamina = GetComponent<Stamina>();
        _playerAnimator = GetComponent<PlayerAnimator>();

        _input = new PlayerInput();
        _input.Player.Attack.performed += _ => Attack();
    }


    private void OnEnable()
    {
        _input.Enable();
    }


    private void OnDisable()
    {
        _input.Disable();
    }


    private void Attack()
    {
        Debug.Log("Attacking");
    }
}
