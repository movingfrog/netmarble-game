using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class printLog1 : MonoBehaviour
{
    public Text Log;
    int index = 0;
    bool already = false;

    // Update is called once per frame
    void Update()
    {
        if (!already)
        {
            switch (index)
            {
                case 0:
                    already = true;
                    Log.DOText("���! ����� �����Ű���?", 1.2f);
                    break;
                case 1:
                    already = true;
                    Log.DOText("��! �˼��մϴ�! �� ������ �մ��� ó���̶�", 1.2f);
                    break;
                case 2:
                    already = true;
                    Log.DOText("Ȥ�� �ֱٿ� �Ͼ ���߿� ���� �ƽó���?", 1.2f);
                    break;
                case 3:
                    already = true;
                    Log.DOText("�� ���� ��ó�� �ִ� �����ҿ� ������ �־����.", 1.2f);
                    break;
                case 4:
                    already = true;
                    Log.DOText("�� Ŀ�ٶ� �����̶� �ֺ� ���鵵 ���ذ� �־��ٰ� �ϴ�����.", 1.2f);
                    break;
                case 5:
                    already = true;
                    Log.DOText("���� ����δ� �� �����ҿ��� ��Ƴ��� ����� ���ٰ� �ؿ�.", 1.2f);
                    break;
                case 6:
                    already = true;
                    Log.DOText("�ϱ� �� ���߿��� ��Ƴ����� ����� �ƴ϶� �����̶�� �ϴ°� �°��Ҥ���", 1.2f);
                    break;
                case 7:
                    already = true;
                    Log.DOText("�׷� ��ſ� ���� �Ǽ���!(���� ���͵� ��������)", 1.2f);
                    break;
            }

        }
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0))
        {
            Touch touch = new Touch();
            if (Input.touchCount != 0)
                touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || (Input.touchCount == 0))
            {
                already = false;
                Log.text = "";
                Log.DOText("", 0.1f);
                if (index != 7)
                    index++;
                else
                {
                    gameObject.SetActive(false);
                    npc2.talking = false;
                    DOTween.To(() => npc2.mainCamera.orthographicSize, x => npc2.mainCamera.orthographicSize = x, 5f, 1f).SetEase(Ease.OutSine);
                }
            }
        }
    }
}
