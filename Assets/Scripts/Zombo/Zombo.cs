using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zombo: MonoBehaviour
{

    private NavMeshAgent _agent;
    [SerializeField]
    private ZomboHealthBar _healthBar;

    [SerializeField]
    private float damage = 8;

    [SerializeField]
    private float attackDelay = 1;

    [SerializeField]
    private float coolDown = 1;

    [SerializeField]
    private float _hp = 40;


    private ZomboState state = ZomboState.following;

    private Vector3 attackPosition;

    private bool isPlayerInsideCollider = false;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _healthBar = GetComponentInChildren<ZomboHealthBar>();
        _healthBar.SetMaxHealth(_hp);
    }


    private void Update()
    {
        if (state == ZomboState.inAttack)
        {
            _agent.SetDestination(attackPosition);
        }

        if (state == ZomboState.following)
        {
            Vector3 targetPosition = Game.instance.Player.transform.position;
            _agent.SetDestination(targetPosition);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(Constants.Tags.Player)) return;
        if (state != ZomboState.following) return;
        state = ZomboState.inAttack;
        StartCoroutine(StartAtack());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Tags.Player)) isPlayerInsideCollider = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constants.Tags.Player)) isPlayerInsideCollider = false;
    }


    private IEnumerator StartAtack()
    {
        attackPosition = Game.instance.Player.transform.position;
        yield return new WaitForSeconds(attackDelay);
        HitPlayer();
        state = ZomboState.coolDown;
        _agent.isStopped = true;
        yield return new WaitForSeconds(coolDown);
        state = ZomboState.following;
        _agent.isStopped = false;
    }


    private void HitPlayer()
    {
        if (!isPlayerInsideCollider) return;
        Game.instance.Player.GetDamage(damage);
    }


    public void GetDamage(float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, _hp);
        _healthBar.UpdateHealth(_hp);
    }
}


enum ZomboState
{
    inAttack,
    following,
    coolDown,
    idle
}