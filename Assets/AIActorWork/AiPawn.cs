using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPawn : MonoBehaviour
{

    public Transform goal;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPath()
    {
        agent.isStopped = false;
    }
}
