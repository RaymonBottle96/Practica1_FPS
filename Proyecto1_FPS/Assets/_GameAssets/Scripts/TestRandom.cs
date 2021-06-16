using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
        
    void Start()
    {
        InvokeRepeating("CreateObject", 5, 5);
        
    }

    void CreateObject() {
        int i = Random.Range(0, objects.Length);
        Instantiate(objects[i], transform.position, Quaternion.identity);
    }
}
