using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchWeapon : MonoBehaviour
{
    [SerializeField]
    int idWeapon;
      

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            other.gameObject.transform.GetChild(0).GetComponent<WeaponManager>().EquipWeapon(idWeapon, true);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
