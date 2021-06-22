using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    [SerializeField] public float health;
    public NavMeshAgent enemy;
    public Transform player;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Death();
        }
    }
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        AttackPlayer();
    }

    public void AttackPlayer() {
        enemy.SetDestination(player.position);
        transform.LookAt(player);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
