using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class Animation : MonoBehaviour
{
    private Light2D light;
    public bool isEnd = false;
    void Start()
    {
        light = GetComponent<Light2D>();
        light.intensity = 0f;
        DOTween.To(() => light.intensity, x => light.intensity = x, 20f, 1.5f).SetEase(Ease.OutQuad);
        StartCoroutine(LightRandom());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator LightRandom()
    {
        yield return new WaitForSeconds(1.5f);
        while (!isEnd)
        {
            light.intensity = Random.Range(20f, 22f);
            yield return null;
        }
    }
}
