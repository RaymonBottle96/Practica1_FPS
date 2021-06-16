using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 50))
            {
                Debug.Log("jose");
                if (hit.collider.gameObject.layer == 16)
                {
                    Destroy(hit.collider.gameObject);
                }
            }

            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit[] hits;
            //hits = Physics.RaycastAll(ray);

            //for (int i = 0; i < hits.Length; i++)
            //{
            //    Debug.Log(hits[i].collider.gameObject.name);

            //}
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
        }
    }


}
