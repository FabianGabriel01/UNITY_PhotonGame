using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameOver : MonoBehaviour
{
    public Text _ScoreDisplay;
    public GameObject _RestartButton, _WaitingFor;

    PhotonView _View;

    // Start is called before the first frame update
    void Start()
    {
        _View = GetComponent<PhotonView>();

        _ScoreDisplay.text = FindObjectOfType<Score>()._Score.ToString();

        if (PhotonNetwork.IsMasterClient == false)
        {
            _RestartButton.SetActive(false);
            _WaitingFor.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRestart()
    {
        _View.RPC("Restart", RpcTarget.All);
    }

    [PunRPC]
    void Restart() 
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
