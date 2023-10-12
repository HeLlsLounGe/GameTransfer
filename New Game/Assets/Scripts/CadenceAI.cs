using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenceAI : MonoBehaviour
{
    [SerializeField] float CadenceCTM = .1f;
    [SerializeField] float MoveCheckPerSecond = 3.5f;
    [SerializeField] float StageAmt = 10f;
    [SerializeField] float TimerToAttack = 10f;
    [SerializeField] GameObject RollerRinkCamera;
    [SerializeField] GameObject DoorCamera;

    bool CadenceActive = true;

    float timer = 0f;
    float timer2 = 0f;
    float Stage = 0;
    bool PlayerAlive = true;
    bool AtDoor = false;
    bool AtSkate = true;
    bool DoorOpen = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (PlayerAlive == false)
        {
            Debug.Log("FUCK YOU BITCH");
            Debug.Log("You Died");
            //Back to menu
            Stage = 0;
            timer = 0f;
            timer2 = 0f;
            PlayerAlive = true;
            AtSkate = true;
            AtDoor = false;
        }
        if (CadenceActive == true)
        {
            timer += Time.deltaTime;
            if (timer > MoveCheckPerSecond)
            {
                timer = 0;
                if (Random.value < CadenceCTM)
                {
                    Stage++;
                    Debug.Log("Stage Progress");
                }
            }
        }
        if (Stage >= StageAmt)
        {
            Stage = 0;
            Debug.Log("Im On My Way");
            AtDoor = true;
            AtSkate = false;

            timer2 += Time.deltaTime;
            if (timer2 > TimerToAttack)
            {
                if (DoorOpen == true)
                {
                    Stage = 0;
                    PlayerAlive = false;
                    Debug.Log("Sup bbg");
                }
                else if (DoorOpen == false)
                {
                    AtDoor = false;
                    AtSkate = true;
                    Stage = 0;
                    Debug.Log("Ow, i ran into the door");
                }
            }
        }

        if (AtDoor == true)
        {
            Vector3 pos = DoorCamera.transform.position;
            pos.z = 0;
            pos.x += -6;
            transform.position = pos;
        }
        if (AtSkate == true)
        {
            Vector3 pos = RollerRinkCamera.transform.position;
            pos.z = 0;
            pos.x += -6;
            transform.position = pos;
        }
    }
}
