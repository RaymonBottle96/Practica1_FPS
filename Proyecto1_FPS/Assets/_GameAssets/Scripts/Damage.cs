using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public HealthManager healthManager;
    [SerializeField]
    int damage;

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAA");
            healthManager.Damage(damage);
        }
    }
}
