using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamage;
    
    public int maxTotalAmmo; //Máximas balas que puede portar
    public int currentAmmo;  //Balas que porto

    public int magazineSize; // Máximas balas que acepta el arma
    public int currentAmmoInMagazine; //Balas en el arma


    private void Start()
    {
        currentAmmoInMagazine = magazineSize;
    }

    private void Update()
    {
        CheckReload();
    }

    public void GetAmmo(int n)
    {
        currentAmmo += n;
        if(currentAmmo> maxTotalAmmo)
        {
            currentAmmo = maxTotalAmmo;
        }
    }

    void CheckReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentAmmo > 0)
            {
                if((magazineSize - currentAmmoInMagazine) > currentAmmo)
                {
                    currentAmmoInMagazine += currentAmmo;
                    currentAmmo = 0;
                }
                else
                {
                    currentAmmo -= (magazineSize - currentAmmoInMagazine);
                    currentAmmoInMagazine = magazineSize;                    
                }
            }
        }
    }
}
