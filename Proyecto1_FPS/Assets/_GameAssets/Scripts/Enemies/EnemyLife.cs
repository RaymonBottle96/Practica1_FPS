using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    int life;

    Rigidbody rb;

    [SerializeField]
    Material material;

    [SerializeField]
    Renderer ms;

    CrazyAgent ag;

    NavMeshAgent nMA;

    [SerializeField]
    EnemyVision enemyVision;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ms = GetComponent<Renderer>();
        ag = GetComponent<CrazyAgent>();
        nMA = GetComponent<NavMeshAgent>();
    }

    public void RemoveLife(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            enemyVision.enabled = false;
            DesactiveParameters();
        }
    }
    
    void DesactiveParameters()
    {
        //Llamada al método EnemyDie de la clase EnemyAnimation
        rb.isKinematic = false;
        ag.enabled = false;
        nMA.enabled = false;
    }
}