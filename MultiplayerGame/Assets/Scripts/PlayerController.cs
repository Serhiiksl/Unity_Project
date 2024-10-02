
using UnityEngine;
using Photon.Pun;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private PhotonView _photonView;
    public float speed = 5f, rotatespeed = 4f;
    public int _attackDamage =25;
    private int _health = 100, force = 50;
    private GameObject effect;


    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
            _rb = GetComponent<Rigidbody>();
        if(! _photonView.IsMine )
            Destroy( GetComponentInChildren<Camera>().gameObject );
    }

    private void FixedUpdate()
    {
        if (!_photonView.IsMine)
            return;
        MovePlayer();
    
    }

    private void Update()
    {
        if (!_photonView.IsMine)
            return;
        RotatePlayer();

        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Camera cam = transform.GetChild(0)?.GetComponent<Camera>();
            //Ray ray = cam.ScreenPointToRay( Input.mousePosition );

            /*if(effect != null)
            {
            //    PhotonNetwork.Destroy(effect);
            }*/

            if(Physics.Raycast(cam.transform.position,cam.transform.forward, out RaycastHit hit))
            {


                effect = PhotonNetwork.Instantiate("Star_B", hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effect, 1f);

                if (hit.collider.CompareTag("Player")) 
                {
                    hit.collider.GetComponent<PlayerController>().Damage(_attackDamage);
                    hit.rigidbody.AddForce(Vector3.up*force);
                }
               
                



            }
        }
    }

    public void Damage(int damage)
    {
        _photonView.RPC("PunDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void PunDamage(int damage) 
    {
        if(!_photonView.IsMine)
            return;

        _health -= damage;
        if (_health <= 0)
            PhotonNetwork.Destroy(gameObject);
    }

    private void RotatePlayer()
    {
        transform.Rotate(Vector3.up * rotatespeed * Input.GetAxis("Horizontal"));
    }

    private void MovePlayer()
    {
       // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        _rb.MovePosition(transform.position + (transform.forward*Time.fixedDeltaTime*speed* Input.GetAxis("Vertical")));

    }
}
