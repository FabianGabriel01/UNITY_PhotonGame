using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy : MonoBehaviour
{
    PlayerController[] Players;
    PlayerController NearestPlayer;
    public float Speed;
    Score _Score;
    public GameObject _DeathFX;
    PhotonView _View;


    // Start is called before the first frame update
    void Start()
    {
        _View = GetComponent<PhotonView>();
        Players = FindObjectsOfType<PlayerController>();
        _Score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    private void Update()
    {
        float DistanceOne = Vector2.Distance(transform.position, Players[0].transform.position);
        float DistanceTwo = Vector2.Distance(transform.position, Players[1].transform.position);

        if (DistanceOne < DistanceTwo)
        {
            NearestPlayer = Players[0];
        }
        else
        {
            NearestPlayer = Players[1];
        }

        if (NearestPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, NearestPlayer.transform.position, Speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (PhotonNetwork.IsMasterClient)
        {
            if (collision.tag == "Hilo")
            {
                _View.RPC("SpawnParticle", RpcTarget.All);
                _Score.AddScore();
                PhotonNetwork.Destroy(this.gameObject);

            }

            if (collision.tag == "Player")
            {
                _View.RPC("SpawnParticle", RpcTarget.All);
                PhotonNetwork.Destroy(this.gameObject);
            }

        }
        /*
        if (PhotonNetwork.IsMasterClient) 
        {
            if (collision.tag == "Hilo") 
            {
                Debug.Log("Destruido");
                
            }
        }
        */
    }

    [PunRPC]
    void SpawnParticle() 
    {
        Instantiate(_DeathFX, transform.position, Quaternion.identity);
    }
}
