using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destiny : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 12)
        {
            //Debug.Log("Target");
            other.gameObject.GetComponent<CrazyAgent>().ChangeDestination();
        }
    }
}
