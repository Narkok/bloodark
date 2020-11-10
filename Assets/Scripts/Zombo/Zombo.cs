using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zombo: MonoBehaviour
{

    private NavMeshAgent _agent;

    [SerializeField]
    private float _damage = 8;

    [SerializeField]
    private float _attackDelay = 1;

    [SerializeField]
    private float _coolDown = 1;

    private Health _health;


    private ZomboState _state = ZomboState.following;

    private Vector3 _attackPosition;

    private bool _isPlayerInsideCollider = false;


    private void Start()
    {
        _health = GetComponent<Health>();
        _agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (_state == ZomboState.inAttack)
        {
            _agent.SetDestination(_attackPosition);
        }

        if (_state == ZomboState.following)
        {
            Vector3 targetPosition = Game.instance.Player.transform.position;
            _agent.SetDestination(targetPosition);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(Constants.Tags.Player)) return;
        if (_state != ZomboState.following) return;
        _state = ZomboState.inAttack;
        StartCoroutine(StartAtack());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Tags.Player)) _isPlayerInsideCollider = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constants.Tags.Player)) _isPlayerInsideCollider = false;
    }


    private IEnumerator StartAtack()
    {
        _attackPosition = Game.instance.Player.transform.position;
        yield return new WaitForSeconds(_attackDelay);
        HitPlayer();
        _state = ZomboState.coolDown;
        _agent.isStopped = true;
        yield return new WaitForSeconds(_coolDown);
        _state = ZomboState.following;
        _agent.isStopped = false;
    }


    private void HitPlayer()
    {
        if (!_isPlayerInsideCollider) return;
        Game.instance.Player.GetDamage(_damage);
    }


    public void GetDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}


enum ZomboState
{
    inAttack,
    following,
    coolDown,
    idle
}