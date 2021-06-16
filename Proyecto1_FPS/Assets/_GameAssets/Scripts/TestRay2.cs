using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay2 : MonoBehaviour
{
    public Camera cam;

    [SerializeField] float rayDistance;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position + transform.right * 0.5f, transform.right);
        Ray ray2 = new Ray(new Vector3(3, 3, 3), new Vector3(0, 1, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, rayDistance))
        {
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
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

    }
}
