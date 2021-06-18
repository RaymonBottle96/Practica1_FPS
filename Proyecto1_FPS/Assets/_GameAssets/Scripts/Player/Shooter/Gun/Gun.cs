using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] public float range;
    public Camera mainCam;

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    public void Shoot() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) {
                target.TakeDamage(damage);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
    }
}
