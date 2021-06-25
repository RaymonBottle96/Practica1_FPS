using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrols : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 20)
        {
            Debug.Log("Patrol");
            if(other.GetComponent<FoolEnemy>() != null)
            other.gameObject.GetComponent<FoolEnemy>().ChangeDestination();            
        }
    }
}