using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmonyAi : MonoBehaviour
{
    [SerializeField] float RoomChoice = .5f;
    [SerializeField] float HarmonyCTM = .1f;
    [SerializeField] float MoveCheckPerSecond = 3.5f;
    [SerializeField] float DieTime = 10f;

    [SerializeField] GameObject stageCamera;
    [SerializeField] GameObject EntranceCamera;
    [SerializeField] GameObject BathroomBCamera;
    [SerializeField] GameObject BathroomGCamera;
    [SerializeField] GameObject CafeteriaCamera;
    [SerializeField] GameObject Hall1Camera;
    [SerializeField] GameObject DoorCamera;

    float timer = 0;
    float timer2 = 0;

    bool HarmonyActive = true;
    bool AtStage = true;
    bool AtEnter = false;
    bool AtEnter2 = false;
    bool AtBrB = false;
    bool AtBrG = false;
    bool AtCafe = false;
    bool AtH1 = false;
    bool AtDoor = false;
    bool PlayerAlive = true;
    bool DoorOpen = false;

    void Start()
    {
        Debug.Log("At Stage");
    }

    void Update()
    {
        if (HarmonyActive == true)
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

                if (Random.value < HarmonyCTM)
                {
                    if (AtStage == true)
                    {
                        AtStage = false;
                        if (Random.value < RoomChoice)
                        {
                            Debug.Log("At Entrance");
                            AtEnter = true;
                        }
                        else
                        {
                            Debug.Log("At Cafeteria");
                            AtCafe = true;
                        }
                    }
                    else if (AtEnter == true)
                    {
                        AtEnter = false;
                        Debug.Log("At Girls Bathroom");
                        AtBrG = true;

                    }
                    else if (AtBrB == true)
                    {
                        AtBrB = false;
                        Debug.Log("At Hall 1");
                        AtH1 = true;
                        
                    }
                    else if (AtBrG == true)
                    {
                        AtBrG = false;
                        if (Random.value < RoomChoice)
                        {
                            Debug.Log("At Entrance");
                            AtEnter2 = true;
                        }
                        else
                        {
                            Debug.Log("At Boys Bathroom");
                            AtBrB = true;
                        }
                    }
                    else if (AtCafe == true)
                    {
                        AtCafe = false;
                        Debug.Log("At Hall 1");
                        AtH1 = true;
                    }
                    else if (AtH1 == true)
                    {
                        AtH1 = false;
                        Debug.Log("Let me IIIIIINNNNN");
                        AtDoor = true;
                    }
                    else if (AtEnter2 == true)
                    {
                        AtEnter2 = false;
                        Debug.Log("At Cafeteria");
                        AtCafe = true;
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
                        Debug.Log("Wanna Kiss?");
                        PlayerAlive = false;
                    }
                    else if (DoorOpen == false)
                    {
                        AtStage = true;
                        Debug.Log("WHYYYYYYYY");
                    }
                    AtDoor = false;
                    timer = 0;

                }
            }



            if (AtStage == true)
            {
                Vector3 pos = stageCamera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
            if (AtEnter == true)
            {
                Vector3 pos = EntranceCamera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
            if (AtBrB == true)
            {
                Vector3 pos = BathroomBCamera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
            if (AtBrG == true)
            {
                Vector3 pos = BathroomGCamera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
            if (AtCafe == true)
            {
                Vector3 pos = CafeteriaCamera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
            if (AtH1 == true)
            {
                Vector3 pos = Hall1Camera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
            if (AtEnter2 == true)
            {
                Vector3 pos = EntranceCamera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
            if (AtDoor == true)
            {
                Vector3 pos = DoorCamera.transform.position;
                pos.z = 0;
                pos.x += 6;
                transform.position = pos;
            }
        }
    }
}
