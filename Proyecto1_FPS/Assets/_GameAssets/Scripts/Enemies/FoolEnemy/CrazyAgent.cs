using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrazyAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] targets;

    [SerializeField]
    public Transform actualTarget;

    [SerializeField]
    public float agentVelocity;

    [SerializeField]
    public int lastPosition;

    public Target enemyDetect;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.speed = agentVelocity;
        ChangeDestination();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(actualTarget.position);
    }

    public virtual void ChangeDestination()
    {
        int temp = Random.Range(0, targets.Length);

        if (lastPosition == temp)
        {
            ChangeDestination();
        }
        else
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            lastPosition = temp;
            StartCoroutine(CoroutineStopSliding(temp));
        }
    }

    public IEnumerator CoroutineStopSliding(int t) //Función para que no se pasen de frenada.
    {
        yield return null;
        actualTarget = targets[t];
        agent.isStopped = false;
    }
/*
    public void DetectEnemy() {
        enemyDetect.AttackPlayer();
    }*/
}
