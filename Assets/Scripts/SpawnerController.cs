using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnerController : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Enemy;
    public float StartTimeBtwSpawns;
    public float TimeBtwSpawn;


    // Start is called before the first frame update
    void Start()
    {
        TimeBtwSpawn = StartTimeBtwSpawns;
    }

    // Update is called once per frame
    private void Update()
    {
        if (PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }


        if (TimeBtwSpawn <= 0)
        {
            //Spawn
            Vector3 SpawnPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)].position;
            PhotonNetwork.Instantiate(Enemy.name, SpawnPosition, Quaternion.identity);
            TimeBtwSpawn = StartTimeBtwSpawns;
        }
        else 
        {
            TimeBtwSpawn -= Time.deltaTime;
        }
    }
}
