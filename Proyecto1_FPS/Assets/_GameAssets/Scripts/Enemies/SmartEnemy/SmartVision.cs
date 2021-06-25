using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartVision : EnemyVision
{    
    [SerializeField]
    SmartAgent smartAgent;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, visionDistance))
        {
            if (hit.collider.gameObject.layer == 10)
            {
                smartAgent.ChasePlayer(hit.collider.transform);
                //Llamada a método inmolación de clase EnemyAnimation
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<EnemyLife>().RemoveLife(10);
        }
    }   
}
