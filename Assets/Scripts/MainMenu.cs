using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public InputField _CreateInput;
    public InputField _JoinInput;
    public Button _Map1, _Map2;
    public string LevelName;

    public InputField _NamePlayer;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom() 
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(_CreateInput.text, roomOptions);
    }

    public void JoinRoom() 
    {
        PhotonNetwork.JoinRoom(_JoinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(LevelName);
    }

    public void Map1() 
    {
        LevelName = "Game";
    }

    public void Map2()
    {
        LevelName = "Game2";
    }

    public void ChangeName() 
    {
        PhotonNetwork.NickName = _NamePlayer.text;
    }
}
