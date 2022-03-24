using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform _target;

    private void Start()=>           
        _target =
            GameObject.FindGameObjectWithTag("Player").transform;
    
    private void Update()
    {       
        transform.LookAt(_target);
        agent.destination = _target.transform.position;                              
    }
}
