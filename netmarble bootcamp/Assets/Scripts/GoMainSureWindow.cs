using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GoMainSureWindow : MonoBehaviour
{
    public RectTransform Window;
    public Button WindowBtn;
    public void WindowDown()
    {
        WindowBtn.interactable = false;
        Window.DOAnchorPos(new Vector2(-3.6292f, 0.9073f), 0.7f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            WindowBtn.interactable = true;
        }).SetUpdate(true);
    }
    public void WindowUp()
    {
        Window.DOAnchorPos(new Vector2(-3.6292f, 500f), 0.7f).SetEase(Ease.OutQuad).OnStart(() =>
        {
            WindowBtn.interactable = false;
        }).SetUpdate(true);
    }
}
