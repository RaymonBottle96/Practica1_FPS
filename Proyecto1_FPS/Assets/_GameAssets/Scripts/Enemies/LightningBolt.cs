using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LightningAttack();
        }
    }


    void LightningAttack()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        /*foreach(GameObject i in enemies) {
            i.GetComponent<Enemy>().RemoveLife();
        }*/

        for (int i = 0; i < enemies.Length; i++)
        {
            int random = Random.Range(1, 11);
            enemies[i].GetComponent<EnemyTest>().RemoveLife(random);
        }
    }
}
