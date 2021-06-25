using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShoot : MonoBehaviour
{
    [SerializeField] WeaponManager weaponManager;

    [SerializeField] LayerMask layerMask;
    [SerializeField] int bulletNumber;

    private void Update() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)) {
            if(bulletNumber > 0) {
                bulletNumber--;
                if(Physics.Raycast(ray.origin, ray.direction, out hit, 50f, layerMask)) {
                    hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(weaponManager.damage);
                }
            }
        }
    }
}
