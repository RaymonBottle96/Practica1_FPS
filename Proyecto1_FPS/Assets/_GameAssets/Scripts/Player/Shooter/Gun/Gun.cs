using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] public float range;
    [SerializeField] public float fireRate;
    [SerializeField] public float impactForce;
    public TMPro.TextMeshProUGUI textBullets;
    [SerializeField] int bulletNumber;
    [SerializeField] int bulletsToRecharge;
    public Camera mainCam;
    public Transform mira;
    public ParticleSystem gunShot;
    public GameObject impactEffect;
    public LayerMask layer;

    private float nextTimeToFire = 0f;

    private void Start() {
        textBullets.text = bulletNumber.ToString();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;
            textBullets.text = bulletNumber.ToString();
            Shoot();
        } if(Input.GetKeyDown(KeyCode.R)) {
            bulletNumber = 0;
            Recharge();
        } if(bulletNumber <= 0) {
            bulletNumber = 0;
        }

        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * range, Color.red);
    }

    public void Shoot() {
        gunShot.Play();
        bulletNumber--;
        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range, layer)) {
            Target target = hit.collider.gameObject.GetComponent<Target>();
            Debug.Log(hit.collider.gameObject.name);
            
            if(target != null) {
                //Debug.Log("Le doy");
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.5f);
        }
    }

    public void Recharge() {
        bulletNumber = bulletsToRecharge;
        bulletsToRecharge = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bullets")) {
            Debug.Log("Balas");
            Destroy(other.gameObject);
            bulletsToRecharge += 50;
        }
    }

}
