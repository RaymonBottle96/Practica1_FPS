using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    //Puntos de patrulla
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Ataque del enemigo
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //Estados
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //enemy.SetDestination(Player.position);

        if(!playerInSightRange && !playerInAttackRange) {
            Patrol();
        } else if(playerInSightRange && !playerInAttackRange) {
            ChasePlayer();
        } else if(playerInAttackRange && playerInSightRange) {
            AttackPlayer();
        }
    }

    private void Patrol() {
        if(!walkPointSet) {
            SearchWalkPoint();
        } else if(walkPointSet) {
            enemy.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Cuando llega el punto de patrulla
        if(distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint() {
        //Calcula un punto aleatorio
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) {
            walkPointSet = true;
        }
    }

    private void ChasePlayer() {
        enemy.SetDestination(player.position);
    }

    private void AttackPlayer() {
        //Al atacar el enemigo se para
        enemy.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked) {

            //TODO codigo de ataque
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            Invoke(nameof(DestroyEnemy), 0.5f);    
        }
    }

    private void DestroyEnemy() {
        Destroy(gameObject);
    }

}
