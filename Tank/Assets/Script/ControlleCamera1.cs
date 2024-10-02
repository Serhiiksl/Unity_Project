using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleCamera1 : MonoBehaviour
{
    float xRot, yRot;
    private GameObject player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = GameObject.Find("Tank Prefab");
          else
           {
            transform.position = player.transform.position + offset;
        MouseMove();
         }
    }

    private void MouseMove()
    {
        xRot += Input.GetAxis("Mouse X");
        yRot += Input.GetAxis("Mouse Y");


        transform.rotation = Quaternion.Euler(-yRot * 1.5f, xRot*0.5f, 0);


    }
}
