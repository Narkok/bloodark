using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomboAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;
    private Transform _transform;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        _transform = transform;
    }


    private void Update()
    {
        if (Vector3.Distance(_player.position, _transform.position) < 20) {
            _agent.SetDestination(_player.position);
        }
    }
}
