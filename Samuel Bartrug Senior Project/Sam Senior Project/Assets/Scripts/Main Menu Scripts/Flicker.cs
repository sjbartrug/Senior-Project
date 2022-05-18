using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    Light myLight;
    public int flicker = 50;
    public float intensity = 600000f;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        if (Random.Range(0, flicker) == 0)
        {
            myLight.intensity = 0.0f; // Flicker by setting intensity to 0 randomly
        }
        else if(Random.Range(0, flicker) == 10)
        {
            myLight.intensity = intensity/2;
        }
        else
        {
            myLight.intensity = intensity;
        }
    }
}
