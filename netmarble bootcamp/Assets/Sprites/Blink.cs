using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public Light2D light2D;
    public GameObject toastPanal;
    private void FixedUpdate()
    {
        StartCoroutine(EMarkerGrid());
    }
    public IEnumerator EMarkerGrid()
    {
        int count = 0;
        yield return new WaitForSeconds(Random.Range(1, 2));
        while (count < 3)
        {
            this.light2D.enabled = false;
            yield return new WaitForSeconds(Random.Range(3f, 7f));
            this.light2D.enabled = true;
            yield return new WaitForSeconds(Random.Range(3f, 7f));
            count++;
        }
    }
}