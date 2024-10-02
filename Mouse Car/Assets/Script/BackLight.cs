
using UnityEngine;

public class BackLight : MonoBehaviour
{
    private Light flight;
    void Start()
    {

        flight = GetComponent<Light>();

    }

    private void Update()
    {
        float vertMove = Input.GetAxis("Vertical");
        if (vertMove < 0)
        {
            flight.range = 20;
        }
        else
            flight.range = 0;
    }
}
