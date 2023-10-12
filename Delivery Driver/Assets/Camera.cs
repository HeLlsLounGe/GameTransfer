using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject ThingToFollow;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ThingToFollow.transform.position + new Vector3 (0,0,-10);
    }
}
