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
                    Log.DOText("어머! 당신은 누구신가요?", 1.2f);
                    break;
                case 1:
                    already = true;
                    Log.DOText("앗! 죄송합니다! 이 마을에 손님은 처음이라…", 1.2f);
                    break;
                case 2:
                    already = true;
                    Log.DOText("혹시 최근에 일어난 폭발에 대해 아시나요?", 1.2f);
                    break;
                case 3:
                    already = true;
                    Log.DOText("얼마 전에 근처에 있던 연구소에 폭발이 있었어요.", 1.2f);
                    break;
                case 4:
                    already = true;
                    Log.DOText("꽤 커다란 폭발이라 주변 집들도 피해가 있었다고 하더라고요.", 1.2f);
                    break;
                case 5:
                    already = true;
                    Log.DOText("정부 조사로는 그 연구소에서 살아남은 사람이 없다고 해요.", 1.2f);
                    break;
                case 6:
                    already = true;
                    Log.DOText("하긴 그 폭발에서 살아남으면 사람이 아니라 괴물이라고 하는게 맞겠죠ㅎㅎ", 1.2f);
                    break;
                case 7:
                    already = true;
                    Log.DOText("그럼 즐거운 여행 되세요!(별로 즐길것도 없지만…)", 1.2f);
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
