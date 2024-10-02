
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3f;
    public float rotateSpeed = 2.8f;
    private Rigidbody rb;


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
            rb.AddTorque(transform.up * horMove * rotateSpeed, ForceMode.Acceleration);
        }

        if ((vertMove > 0 || vertMove < 0)) { 
        rb.AddForce(transform.forward * speed * vertMove, ForceMode.Acceleration);
        }

    }
 
}
