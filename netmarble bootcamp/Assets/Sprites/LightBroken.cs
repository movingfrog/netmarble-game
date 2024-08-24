using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightBroken : MonoBehaviour
{
    public float Angle;
    public float Duration;
    private int Random = 0;
    void Start()
    {
        Sequence rotationSequence = DOTween.Sequence();
        rotationSequence.Append(transform.DORotate(new Vector3(0, 0, Angle), Duration).SetEase(Ease.InOutSine));
        rotationSequence.Append(transform.DORotate(new Vector3(0, 0, -Angle), Duration).SetEase(Ease.InOutSine));
        rotationSequence.SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
