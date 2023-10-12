using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Attack;
    void OnFire(InputValue value)
    {

        GameObject bullet = Instantiate(Attack, transform.position, Quaternion.identity);
        Destroy(bullet, 0.02f);
    }
}
