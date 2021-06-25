using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float visionDistance = 3f;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); 
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, visionDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                //hit.collider.gameObject.GetComponent<EnemyLife>().RemoveLife(50);
                Destroy(gameObject);
            }
        }       
        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);
    }
}
