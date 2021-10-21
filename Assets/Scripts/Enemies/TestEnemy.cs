using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    public void MoveTo(Vector3 targetPositionon)
    {
        _agent.SetDestination(targetPositionon);
    }

    public void WarpTo(Vector3 position)
    {
        _agent.Warp(position);
    }
}
