using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    
    GameObject[] weapons;
    GameObject actualWeapon;
    bool[] availableWeapon;
    int damage;

    void Start()
    {
        //damage = actualWeapon.GetComponent<Weapon>().weaponDamage;
    }

    void EquipWeapon(int n) {
        actualWeapon.SetActive(false);
        actualWeapon = weapons[n];

    }

    
    void Update()
    {
        
    }
}
