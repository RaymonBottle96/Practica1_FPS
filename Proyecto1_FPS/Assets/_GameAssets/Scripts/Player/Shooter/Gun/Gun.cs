using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] public float range;
    [SerializeField] public float fireRate;
    [SerializeField] public float impactForce;
    public Camera mainCam;
    public ParticleSystem gunShot;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    private void Update() {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public void Shoot() {
        gunShot.Play();
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range)) {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.5f);
        }
    }
}
