using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject Light;
    float x = 1;
    float y = 0;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 PointDir = mousePosition - transform.position;
        PointDir.z = 0;
        PointDir.Normalize();
        x = PointDir.x;
        y = PointDir.y;
        transform.up = PointDir;
    }
}
