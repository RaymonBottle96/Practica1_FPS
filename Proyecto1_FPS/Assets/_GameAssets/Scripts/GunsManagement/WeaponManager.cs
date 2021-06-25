using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;

    public GameObject actualWeapon;

    [SerializeField]
    bool[] availableWeapons;

    public int damage;    


    private void Start()
    {
        damage = actualWeapon.GetComponent<Weapon>().weaponDamage;
        EquipWeapon(1, true);
    }

    public void EquipWeapon(int n, bool isCatch)
    {
        actualWeapon.SetActive(false);
        actualWeapon = weapons[n];
        weapons[n].SetActive(true);
        availableWeapons[n] = true;
        damage = weapons[n].GetComponent<Weapon>().weaponDamage;
        if (isCatch)
        {
            weapons[n].GetComponent<Weapon>().GetAmmo(weapons[n].GetComponent<Weapon>().magazineSize);
        }
    }

    void Update()
    {
        CheckChangeWeapon();
    }

    void CheckChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (availableWeapons[0] == true)
            {
                EquipWeapon(0, false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (availableWeapons[1] == true)
            {
                EquipWeapon(1, false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (availableWeapons[2] == true)
            {
                EquipWeapon(2, false);
            }
        }
    }
}
