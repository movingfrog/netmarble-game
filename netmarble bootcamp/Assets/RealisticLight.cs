using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RealisticLight : MonoBehaviour
{
    public Light2D light2D;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        light2D.intensity = Random.Range(4.5f, 5.1f);
    }
}
