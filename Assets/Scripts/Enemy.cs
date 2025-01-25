using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Material hitMaterial; // Assign a different material in the Inspector
    public Material originalMaterial;
    public bool isHit = false; // Flag to track if the enemy has been hit

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask ground, whatPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject fireBall;

    public float timer = 5f;
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatPlayer);

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatPlayer);

        if(!playerInSightRange && !playerInAttackRange && !isHit)
        {
            Patroling();
        }

        if(playerInSightRange && !playerInAttackRange && !isHit)
        {
            ChasePlayer();
        }

        if(playerInSightRange && playerInAttackRange && !isHit)
        {
            AttackPlayer();
        }

        if (isHit)
        {
            

            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                isHit = false;
                GetComponent<Renderer>().material = originalMaterial;
                timer = 5;
            }
        }
    }

    private void Patroling()
    {
        if(!walkPointSet)
        {
            SearchWalkPoint();
        }

        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, ground))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(fireBall, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            ChangeColor();
            isHit = true;
        }

        if (collision.gameObject.CompareTag("Player") && isHit)
        {
            Destroy(gameObject); 
        }
    }

    void ChangeColor()
    {
        // Change the enemy's material to the new material
        GetComponent<Renderer>().material = hitMaterial;
    }
}
