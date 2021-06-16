using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    LifePlayer lifePlayer;
    public int lifeCounter;
    public float damageTime;
    float currentDamageTime;
    private void Start() {
        lifePlayer = GameObject.FindWithTag("Player").GetComponent<LifePlayer>();
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime) {
                lifePlayer.life += lifeCounter;
                currentDamageTime = 0.0f;
            }
        }
    }
}
