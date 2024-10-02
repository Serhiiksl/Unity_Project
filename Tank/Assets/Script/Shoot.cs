using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float timeshoot = 1.5f;
    public GameObject shootcfere, tureltank;
    private float powerExplotion = 40f;
    public bool intmbtn = false;
    private bool shootbool = true;
    private float timeforshoot = 0f;
    [SerializeField] private GameObject _particles;

    void Update()
    {


        ShootTank();

    }

    private void ShootTank()
    {
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
        if (intmbtn & shootbool)
        {
            Vistrel_Snaryada();
            shootbool = false;
            timeforshoot = 0;

        }

    }

    private void Vistrel_Snaryada()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
        GameObject snaryad = Instantiate(shootcfere) as GameObject;
        snaryad.transform.position = tureltank.transform.position;
        snaryad.transform.rotation = tureltank.transform.rotation;
        snaryad.transform.Translate(0, 0, 0, Space.Self);
        snaryad.GetComponent<Rigidbody>().AddRelativeForce(-snaryad.transform.up * powerExplotion, ForceMode.VelocityChange);


    }
}
