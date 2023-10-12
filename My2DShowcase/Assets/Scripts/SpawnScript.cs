using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] float SpawnTimer = 20f;
    [SerializeField] float SpawnChance = .5f;
    [SerializeField] GameObject Enemy;
    float Timer = 0f;

    public void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > SpawnTimer)
        {
            Debug.Log("check");
            Timer = 0f;
            if (Random.value < SpawnChance)
            {
                Debug.Log("Spawned");
                GameObject Spawn = Instantiate(Enemy, transform.position, Quaternion.identity);
                Spawn.GetComponent<EnemyBehavior>().player = player;
            }
        }
    }
}
