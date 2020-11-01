using UnityEngine;
using UnityEngine.AI;

public class ZomboAI : MonoBehaviour
{
    private NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        Vector3 targetPosition = Managers.instance.Player.Player.position;
        _agent.SetDestination(targetPosition);
    }
}
