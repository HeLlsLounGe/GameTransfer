using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FnafCode : MonoBehaviour
{
    [SerializeField] float RoomChoice = .5f;
    [SerializeField] float MonsterCTM = .1f;
    [SerializeField] float MoveCheckPerSecond = 3.5f;
    [SerializeField] float DieTime = 10f;

    [SerializeField] GameObject stageCamera;
    [SerializeField] GameObject CafeteriaCamera;
    [SerializeField] GameObject KitchenCamera;
    [SerializeField] GameObject Hall1Camera;
    [SerializeField] GameObject Hall2Camera;
    [SerializeField] GameObject MaintenenceCamera;
    [SerializeField] GameObject DoorCamera;

    float timer = 0;
    float timer2 = 0;

    bool MonsterActive = true;
    bool AtStage = true;
    bool AtCafe = false;
    bool AtKitch = false;
    bool AtH1 = false;
    bool AtH2 = false;
    bool AtMaint = false;
    bool AtDoor = false;
    bool PlayerAlive = true;
    bool DoorOpen = true;

    void Start()
    {
        Debug.Log("At Stage");
    }

    void Update()
    {
        if (MonsterActive == true)
        {
            if (PlayerAlive == false)
            {
                PlayerAlive = true;
                AtStage = true;
                Debug.Log("Back at Stage");
                Debug.Log("you died");
                //start at menu
            }

            timer += Time.deltaTime;
            if (timer > MoveCheckPerSecond)
            {
                timer = 0;

                Debug.Log("move check");

                if (Random.value < MonsterCTM)
                {
                    if (AtStage == true)
                    {
                        AtStage = false;
                        AtCafe = true;
                        Debug.Log("At Cafeteria");
                    }
                    else if (AtCafe == true)
                    {
                        AtCafe = false;

                        if (Random.value < RoomChoice)
                        {
                            Debug.Log("At Hall 2");
                            AtH2 = true;
                        }
                        else
                        {
                            Debug.Log("At Kitchen");
                            AtKitch = true;
                        }
                    }
                    else if (AtH2 == true)
                    {
                        AtH2 = false;
                        if (Random.value < RoomChoice)
                        {
                            Debug.Log("At Maintenence");
                            AtMaint = true;
                        }
                        else
                        {
                            Debug.Log("Knock Knock baby");
                            AtDoor = true;
                        }
                    }
                    else if (AtMaint == true)
                    {
                        AtMaint = false;
                        Debug.Log("Knock Knock baby");
                        AtDoor = true;
                    }
                    else if (AtKitch == true)
                    {
                        AtKitch = false;
                        Debug.Log("At Hall 1");
                        AtH1 = true;
                    }
                    else if (AtH1 == true)
                    {
                        AtH1 = false;
                        Debug.Log("At Hall 2");
                        AtH2 = true;
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
                        Debug.Log("GOTCHA BITCH");
                        PlayerAlive = false;
                    }
                    else if (DoorOpen == false)
                    {
                        AtStage = true;
                        Debug.Log("dang, doors shut");
                    }
                    AtDoor = false;
                    timer = 0;

                }
            }



            if (AtStage == true)
            {
                Vector3 pos = stageCamera.transform.position;
                pos.z = 0;
                pos.x += 2;
                transform.position = pos;
            }
            if (AtCafe == true)
            {
                Vector3 pos = CafeteriaCamera.transform.position;
                pos.z = 0;
                pos.x += 2;
                transform.position = pos;
            }
            if (AtKitch == true)
            {
                Vector3 pos = KitchenCamera.transform.position;
                pos.z = 0;
                pos.x += 2;
                transform.position = pos;
            }
            if (AtH1 == true)
            {
                Vector3 pos = Hall1Camera.transform.position;
                pos.z = 0;
                pos.x += 2;
                transform.position = pos;
            }
            if (AtH2 == true)
            {
                Vector3 pos = Hall2Camera.transform.position;
                pos.z = 0;
                pos.x += 2;
                transform.position = pos;
            }
            if (AtMaint == true)
            {
                Vector3 pos = MaintenenceCamera.transform.position;
                pos.z = 0;
                pos.x += 2;
                transform.position = pos;
            }
            if (AtDoor == true)
            {
                Vector3 pos = DoorCamera.transform.position;
                pos.z = 0;
                pos.x += 2;
                transform.position = pos;
            }
        }
    }
}




