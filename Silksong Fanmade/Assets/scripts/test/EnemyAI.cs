using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //pratoling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void awake()
    {
        
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void update()
    {
        //check sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange, whatIsPlayer);
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();

    }

    private void Patroling()
    {
        
        

    }


   
}
