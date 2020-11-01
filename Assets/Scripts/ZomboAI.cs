using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomboAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        /// Исправить поиск игрока
        _player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }


    private void Update()
    {
        if (_player == null) return;
        _agent.SetDestination(_player.position);
    }
}
