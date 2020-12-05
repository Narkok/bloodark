using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerAttack : MonoBehaviour
{
    private Stamina _stamina;
    private PlayerInput _input;
    private PlayerAnimator _playerAnimator;

    [SerializeField]
    private Weapon _weapon;

    [SerializeField]
    private float _attackTime = 1;

    [SerializeField]
    private float _staminaForAttack = 10;

    private bool _inAttack = false;


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
        if (_inAttack) return;
        if (_stamina.Value < _staminaForAttack) return;

        _inAttack = true;
        _stamina.Decrease(_staminaForAttack);
        _playerAnimator.StartAttack();
        _weapon?.ActivateCollider();

        StartCoroutine(AttackStopper());
    }


    private IEnumerator AttackStopper()
    {
        yield return new WaitForSeconds(_attackTime);

        _inAttack = false;
        _weapon?.DeactivateCollider();
        _playerAnimator.StopAttack();
    }
}
