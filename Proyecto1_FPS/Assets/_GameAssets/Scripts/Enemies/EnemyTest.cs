using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] int life;
    int random;

    public void RemoveLife(int damage) {
        life = life - damage;
    }
}
