using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthPlayer : MonoBehaviour
{
    public int _Health = 10;
    public Text _HealthDisplay;

    PhotonView _View;

    public GameObject _GameOver;


    // Start is called before the first frame update
    void Start()
    {
        _View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage() 
    {
        /*
        _Health--;
        _HealthDisplay.text = _Health.ToString();
        */

        _View.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    void TakeDamageRPC() 
    {
        _Health--;

        if (_Health <=0) 
        {
            _GameOver.SetActive(true);
        }
        _HealthDisplay.text = _Health.ToString();
    }
}
