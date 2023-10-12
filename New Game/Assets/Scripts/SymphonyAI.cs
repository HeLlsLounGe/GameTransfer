using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymphonyAI : MonoBehaviour
{
    [SerializeField] float SymphonyCTM = .1f;
    [SerializeField] float MoveCheckPerSecond = 3.5f;
    [SerializeField] float DieTime = 10f;

    [SerializeField] GameObject stageCamera;
    [SerializeField] GameObject EntranceCamera;
    [SerializeField] GameObject Maintenence2Camera;
    [SerializeField] GameObject RollerCoasterCamera;
    [SerializeField] GameObject Hall2Camera;
    [SerializeField] GameObject MaintenenceCamera;
    [SerializeField] GameObject DoorCamera;

    bool SymphonyActive = true;
    bool AtStage = true;
    bool AtEnter = false;
    bool AtMaint2 = false;
    bool AtCoaster = false;
    bool AtH2 = false;
    bool AtMaint = false;
    bool AtDoor = false;
    float timer = 0;
    float timer2 = 0;
    bool PlayerAlive = true;
    bool DoorOpen = true;

    void Start()
    {
        Debug.Log("At Stage");
    }

    void Update()
    {
        if (SymphonyActive == true)
        {


            if (PlayerAlive == false)
            {
                PlayerAlive = true;
                AtMaint = true;
                Debug.Log("Next Time");
                Debug.Log("you died");
                //start at menu
            }

            timer += Time.deltaTime;
            if (timer > MoveCheckPerSecond)
            {
                timer = 0;

                Debug.Log("move check");

                if (Random.value < SymphonyCTM)
                {
                    if (AtStage == true)
                    {
                        AtStage = false;
                        AtEnter = true;
                        Debug.Log("At Entrance");
                    }
                    else if (AtEnter == true)
                    {
                        AtEnter = false;
                        AtMaint2 = true;
                        Debug.Log("At Maintenence 2");
                    }
                    else if (AtMaint2 == true)
                    {
                        AtMaint2 = false;
                        AtCoaster = true;
                        Debug.Log("At Roller Coaster");
                    }
                    else if (AtCoaster == true)
                    {
                        AtCoaster = false;
                        AtH2 = true;
                        Debug.Log("At Roller Coaster");
                    }
                    else if (AtH2 == true)
                    {
                        AtH2 = false;
                        AtMaint = true;
                        Debug.Log("At Maintenence");
                    }
                    else if (AtMaint == true)
                    {
                        AtMaint = false;
                        Debug.Log("Hellooooo!");
                        AtDoor = true;
                    }
                }

            }
            if (AtDoor == true)
            {
                timer2 += Time.deltaTime;
                if (timer2 > DieTime)
                {
                    if (DoorOpen == true)
                    {
                        Debug.Log("Your Dead Whore");
                        PlayerAlive = false;
                    }
                    else if (DoorOpen == false)
                    {
                        AtStage = true;
                        Debug.Log("dagnabbit, i hate doors");
                    }
                    AtDoor = false;
                    timer = 0;

                }
            }



            if (AtStage == true)
            {
                Vector3 pos = stageCamera.transform.position;
                pos.z = 0;
                pos.x += -4;
                transform.position = pos;
            }
            if (AtEnter == true)
            {
                Vector3 pos = EntranceCamera.transform.position;
                pos.z = 0;
                pos.x += -4;
                transform.position = pos;
            }
            if (AtMaint2 == true)
            {
                Vector3 pos = Maintenence2Camera.transform.position;
                pos.z = 0;
                pos.x += -4;
                transform.position = pos;
            }
            if (AtCoaster == true)
            {
                Vector3 pos = RollerCoasterCamera.transform.position;
                pos.z = 0;
                pos.x += -4;
                transform.position = pos;
            }
            if (AtH2 == true)
            {
                Vector3 pos = Hall2Camera.transform.position;
                pos.z = 0;
                pos.x += -4;
                transform.position = pos;
            }
            if (AtMaint == true)
            {
                Vector3 pos = MaintenenceCamera.transform.position;
                pos.z = 0;
                pos.x += -4;
                transform.position = pos;
            }
            if (AtDoor == true)
            {
                Vector3 pos = DoorCamera.transform.position;
                pos.z = 0;
                pos.x += -4;
                transform.position = pos;
            }
        }
    }
}
