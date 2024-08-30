using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainToGameScene : MonoBehaviour
{
    public GameObject Camera;
    public Light2D light;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public void CloseMainScene()
    {
        Camera.transform.DOMoveY(-9.6f, 1.5f).SetEase(Ease.InQuad);
        light.GetComponent<Animation>().isEnd = true;
        DOTween.To(() => light.intensity, x => light.intensity = x, 0f, 1.5f).SetEase(Ease.OutQuad);
        StartCoroutine(MainChange());
    }
    IEnumerator MainChange()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Lab");
    }
    public void ExitGame()
    {
        Camera.transform.DOMoveY(-9.6f, 1.5f).SetEase(Ease.InQuad);
        light.GetComponent<Animation>().isEnd = true;
        DOTween.To(() => light.intensity, x => light.intensity = x, 0f, 1.5f).SetEase(Ease.OutQuad);
        StartCoroutine(Exit());
    }
    IEnumerator Exit()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
    public void BtnDisable()
    {
        btn1.interactable =false;
        btn2.interactable =false;
        btn3.interactable =false;
    }
    public void BtnEnable()
    {
        btn1.interactable = true;
        btn2.interactable = true;
        btn3.interactable = true;
    }
}
