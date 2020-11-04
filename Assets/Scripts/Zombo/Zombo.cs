using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zombo: MonoBehaviour
{

    private NavMeshAgent _agent;
    private Collider _collider;

    [SerializeField]
    private int damage = 8;

    [SerializeField]
    private float attackDelay = 1;

    [SerializeField]
    private float coolDown = 1;


    private ZomboState state = ZomboState.following;

    private Vector3 attackPosition;

    private bool isPlayerInsideCollider = false;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
    }


    private void Update()
    {
        if (state == ZomboState.coolDown)
        {
        }

        if (state == ZomboState.inAttack)
        {
            _agent.SetDestination(attackPosition);
        }

        if (state == ZomboState.following)
        {
            Vector3 targetPosition = Managers.instance.PlayerManager.Player.transform.position;
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
        attackPosition = Managers.instance.PlayerManager.Player.transform.position;
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
        Managers.instance.PlayerManager.Player.GetDamage(damage);
    }
}


enum ZomboState
{
    inAttack,
    following,
    coolDown,
    idle
}