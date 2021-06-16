using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour
{
   [SerializeField]
   int life;
   public HealthManager healthManager;

    private void Awake() {
        if(healthManager == null) {
            healthManager = FindObjectOfType<HealthManager>();
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("AY QUE RICO");
            healthManager.AddLife(life);
        }
    }
}
