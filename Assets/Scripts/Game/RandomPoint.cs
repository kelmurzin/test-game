using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RandomPoint : MonoBehaviour
{
    [SerializeField] private float range = 10;
    [SerializeField] private float time;

    NavMeshAgent agent;    
    Vector3 point;
   
    private void Start()
    {
       agent = GetComponent<NavMeshAgent>();      
       StartCoroutine(FindPoint());
    }

    IEnumerator FindPoint()
    {        
        while (true)
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * range, out hit, range, NavMesh.AllAreas);
            point =hit.position;            
            agent.SetDestination(point);
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            yield return new WaitForSeconds(time);
        }                     
    }    
}
