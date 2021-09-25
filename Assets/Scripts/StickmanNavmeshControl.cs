using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StickmanNavmeshControl : MonoBehaviour
{
    GameObject target; 
    NavMeshAgent navMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        target = GameObject.FindGameObjectWithTag("EnemyHouse");
        navMeshAgent.SetDestination(target.transform.position);
    }
}
