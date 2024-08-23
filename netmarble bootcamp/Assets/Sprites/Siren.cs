using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Siren : MonoBehaviour
{
    public Light2D light2D;
    private void Start()
    {
        StartCoroutine(siren());
    }
    IEnumerator siren()
    {
        while (true)
        {
            light2D.enabled = true;
            yield return new WaitForSeconds(0.3f);
            light2D.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
