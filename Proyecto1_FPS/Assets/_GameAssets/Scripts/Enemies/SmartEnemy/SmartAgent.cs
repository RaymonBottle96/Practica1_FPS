using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmartAgent : CrazyAgent
{
    [SerializeField]
    int nextPosition;

    public override void  ChangeDestination()
    {
        nextPosition++;

        if (nextPosition == 5)
        {
            nextPosition = 0;
        }
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        StartCoroutine(CoroutineStopSliding(nextPosition));        
    }

    public void ChasePlayer(Transform t)
    {
        actualTarget = t;
    }
}
