
using UnityEngine;


public class FrontLight : MonoBehaviour
{
    private Light flight;
      void Start()
      {

        flight = GetComponent<Light>();

     }

    private void Update()
    {
        float vertMove = Input.GetAxis("Vertical");
        if (vertMove > 0)
        {
            flight.range = 50;
        }
        else 
        flight.range = 0;
    }
}
