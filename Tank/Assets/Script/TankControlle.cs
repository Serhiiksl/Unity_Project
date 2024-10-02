using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlle : MonoBehaviour
{
    public float speed = 3f;
    public float rotateSpeed = 2.8f;
    private Rigidbody rb;
    public GameObject hullTank;
    public float maxUp=0, Up;
    public float timeshoot = 1.5f;
    public bool intmbtn = false;
    private bool shootbool = true;
    private float timeforshoot = 0f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }
    private void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        if (horMove > 0 || horMove < 0)
        {
            // rb.AddTorque(transform.up * horMove * rotateSpeed, ForceMode.Force);
            transform.Rotate(Vector3.up * rotateSpeed * horMove*Time.deltaTime);
        }

        if ((vertMove > 0 || vertMove < 0) && rb.velocity.magnitude < 15 )
        {
            rb.AddForce(transform.forward * speed * vertMove, ForceMode.Force);
            // rb.inertiaTensor = Vector3.right;

            if (maxUp > -5)
            {
                maxUp -= 0.1f;
                Up = 0f;
                hullTank.transform.localRotation = Quaternion.Euler(maxUp + Up, 0, 0);
            }
        }

        if(vertMove == 0 && rb.velocity != Vector3.zero) {

            if (maxUp < 5)
            {
                maxUp += 0.1f;
                Up = 0f;
                hullTank.transform.localRotation = Quaternion.Euler(maxUp + Up, 0, 0);
            }

        }
        
        else if (vertMove == 0 && rb.velocity==Vector3.zero)
        {
            Up = 0f;
            if(maxUp>0)
                maxUp -= 0.1f;
            else if(maxUp<=0)
                maxUp += 0.1f;
            hullTank.transform.localRotation = Quaternion.Euler(Up+maxUp, 0, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            intmbtn = true;
        }
        else
        {
            intmbtn = false;
        }
        timeforshoot += Time.deltaTime;
        if (timeforshoot >= timeshoot)
        {
            shootbool = true;

        }
        if (intmbtn && shootbool)
        {
            rb.AddForce(transform.forward * speed * -1, ForceMode.Impulse);
            shootbool = false;
            timeforshoot = 0;

        }

    }
}
