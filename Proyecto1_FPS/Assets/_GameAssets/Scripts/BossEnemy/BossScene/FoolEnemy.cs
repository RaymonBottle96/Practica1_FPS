using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoolEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] targets;

    [SerializeField]
    public Transform actualTarget;

    [SerializeField]
    public float agentVelocity;

    [SerializeField]
    public int lastPosition;

    //public Animator bossEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        targets = GameObject.FindGameObjectsWithTag("Destiny");
        actualTarget = targets[Random.Range(0, targets.Length)].transform;
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
            //bossEnemy.SetBool("walking", true);
        }
        else
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            lastPosition = temp;
            StartCoroutine(CoroutineStopSliding(temp));
            //bossEnemy.SetBool("Idle", true);
        }
    }

    public IEnumerator CoroutineStopSliding(int t) //Función para que no se pasen de frenada.
    {
        yield return null;
        actualTarget = targets[t].transform;
        agent.isStopped = false;
    }

}
