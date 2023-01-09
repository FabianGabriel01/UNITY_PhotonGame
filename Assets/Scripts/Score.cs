using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int _Score = 0;
    PhotonView _View;
    public Text _ScoreDisplay;


    // Start is called before the first frame update
    void Start()
    {
        _View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore() 
    {
        _View.RPC("AddScoreRPC", RpcTarget.All);
    }


    [PunRPC]
    void AddScoreRPC() 
    {
        _Score++;
        _ScoreDisplay.text = _Score.ToString();
    }
}
