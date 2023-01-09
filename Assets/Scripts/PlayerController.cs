using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float _Speed, _DashSpeed, _DashTime;
    PhotonView View;
    HealthPlayer HealthScript;
    LineRenderer _HiloRend;
    float _ResetSpeed;
    public float MinX, MaxX, MinY, MaxY;

    public Text _NameDisplay;

    public bool _IsfacingLeft;
    public Animator _Animator;


    // Start is called before the first frame update
    void Start()
    {
        _ResetSpeed = _Speed;
        View = GetComponent<PhotonView>();
        HealthScript = FindObjectOfType<HealthPlayer>();
        _HiloRend = FindObjectOfType<LineRenderer>();

        if (View.IsMine)
        {
            _NameDisplay.text = PhotonNetwork.NickName;
        }
        else 
        {
            _NameDisplay.text = View.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() 
    {
        if (View.IsMine)
        {
            Vector2 MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 MoveAmount = MoveInput.normalized * _Speed * Time.deltaTime;
            transform.position += (Vector3)MoveAmount;

            Wrap();


            _HiloRend.SetPosition(0, transform.position);


            if (Input.GetKeyDown(KeyCode.Space) && MoveInput != Vector2.zero) 
            {
                StartCoroutine(Dash());
            }



            _Animator.SetFloat("Left", MoveInput.x);
            //_Animator.SetFloat("Right", MoveInput.x);








        }
        else 
        {
            _HiloRend.SetPosition(1, transform.position);
        }
    }


    IEnumerator Dash() 
    {
        _Speed = _DashSpeed;
        yield return new WaitForSeconds(_DashTime);
        _Speed = _ResetSpeed;
    }

    void Wrap() 
    {
        if (transform.position.x < MinX) 
        {
            transform.position = new Vector2(MaxX, transform.position.y);
        }

        if (transform.position.x > MaxX)
        {
            transform.position = new Vector2(-MaxX, transform.position.y);
        }

        if (transform.position.y < MinY)
        {
            transform.position = new Vector2(transform.position.x, MaxY);
        }
        if (transform.position.y > MaxY)
        {
            transform.position = new Vector2(transform.position.x, MinY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (View.IsMine) 
        {
            if (collision.tag == "Enemy") 
            {
                HealthScript.TakeDamage();
            }
        }
    }
}
