using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Text Text;

    private void Awake()
    {
        StartCoroutine("ToBeContinued");
    }

    IEnumerator ToBeContinued()
    {
        yield return new WaitForSeconds(0.3f);
        Text.color = new Color(255f, 255f, 255f, 0.4f);
        DOTween.To(() => Text.color, x => Text.color = x, new Color(255f, 255f, 255f, 1f), 3f);
        DOTween.To(() => Text.fontSize, x => Text.fontSize = x, 100, 3f);
    }
}
