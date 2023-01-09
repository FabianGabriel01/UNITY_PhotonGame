using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Spawner : MonoBehaviour
{
    public GameObject _Player;
    public float _MinX, _MinY, _MaxX, _MaxY;

    // Start is called before the first frame update
    private void Start()
    {
        Vector2 _randomPosition = new Vector2(Random.Range(_MinX, _MaxX), Random.Range(_MinY, _MaxY));
        PhotonNetwork.Instantiate(_Player.name, _randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
