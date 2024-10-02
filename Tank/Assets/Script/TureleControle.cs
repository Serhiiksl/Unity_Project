using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TureleControle : MonoBehaviour
{
    public GameObject turele;
    float zRot, yRot;

    private void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        zRot  +=  Input.GetAxis("Mouse X");
        yRot += Input.GetAxis("Mouse Y");
        if (zRot >= -50 && zRot <= 50 && yRot >= -5 && yRot <= 50)
            turele.transform.localRotation = Quaternion.Euler(-yRot, 0, zRot);
        else if (zRot < -50)
            zRot = -50;
        else if (zRot > 50)
            zRot = 50;
        else if (yRot < -5)
            yRot = -5;
        else if (yRot > 50)
            yRot = 50;




    }
}
