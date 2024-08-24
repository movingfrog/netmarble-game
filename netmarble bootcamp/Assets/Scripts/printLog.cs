using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class printLog : MonoBehaviour
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
                    Log.text = "";
                    Log.DOText("…? 자네는 누구지?", 1.2f);
                    break;
                case 1:
                    already = true;
                    Log.text = "";
                    Log.DOText("음 처음 보는 사람인데… 손님인건가?", 1.2f);
                    break;
                case 2:
                    already = true;
                    Log.text = "";
                    Log.DOText("허허, 이 마을에 진짜 오랜만에 손님이 왔구먼.", 1.2f);
                    break;
                case 3:
                    already = true;
                    Log.text = "";
                    Log.DOText("자네, 혹시 그 사건을 조사하러 온건가?", 1.2f);
                    break;
                case 4:
                    already = true;
                    Log.text = "";
                    Log.DOText("음, 모르는 것 같은 눈치로군.", 1.2f);
                    break;
                case 5:
                    already = true;
                    Log.text = "";
                    Log.DOText("하긴, 요즘 햇병아리들은 전쟁이 일어난 줄도 모르더라.", 1.2f);
                    break;
                case 6:
                    already = true;
                    Log.text = "";
                    Log.DOText("말 나온 김에 한번 알려주지. 이건 비밀이야.", 1.2f);
                    break;
                case 7:
                    already = true;
                    Log.text = "";
                    Log.DOText("기억조차 희미한 코흘리게 시절에는, 사람들이 이 썩어빠진 지하가 아니라 하늘이 보이는 지상에서 살았었지.", 1.2f);
                    break;
                case 8:
                    already = true;
                    Log.text = "";
                    Log.DOText("아름다운 풍경, 밝은 천장, 즐거운 아이들의 웃음소리들,", 1.2f);
                    break;
                case 9:
                    already = true;
                    Log.text = "";
                    Log.DOText("하지만 이 소중한 것들이 사라지는 건 한순간이었어.", 1.2f);
                    break;
                case 10:
                    already = true;
                    Log.text = "";
                    Log.DOText("어느 날, 갑자기 하늘에서 찢어질 것 같은 굉음이 들리고 하늘에는 버섯 구름이 보였더래.", 1.2f);
                    break;
                case 11:
                    already = true;
                    Log.text = "";
                    Log.color = Color.red;
                    Log.fontSize += 10;
                    Log.DOText("나라끼리 핵전쟁을 시작한거지.", 1.2f);
                    break;
                case 12:
                    already = true;
                    Log.text = "";
                    Log.color = Color.white;
                    Log.fontSize -= 10;
                    Log.DOText("그렇게 사람들이 처참하게 죽어나갔어.", 1.2f);
                    break;
                case 13:
                    already = true;
                    Log.text = "";
                    Log.DOText("남은 사람들은 살기 위해 지하로 피신을 시작했고", 1.2f);
                    break;
                case 14:
                    already = true;
                    Log.text = "";
                    Log.DOText("지하에서 거주한 사람들끼리 뭉치면서 이 마을이 만들어진거지.", 1.2f);
                    break;
                case 15:
                    already = true;
                    Log.text = "";
                    Log.DOText("뭐, 워낙 어렸을 때 일이라 나도 자세한 일은 잘 몰라.", 1.2f);
                    break;
                case 16:
                    already = true;
                    Log.text = "";
                    Log.DOText("지금은 망할 정부 놈들이 전쟁 일은 싹 다 말소시켜서 말이지.", 1.2f);
                    break;
                case 17:
                    already = true;
                    Log.text = "";
                    Log.DOText("아무튼, 이 마을에서 즐기다가 가시게. 즐길거리는 없지만 말이야.", 1.2f);
                    break;
            }

        }
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0))
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || (Input.touchCount == 0))
            {
                already = false;
                if (index != 17)
                    index++;
                else
                    gameObject.SetActive(false);
            }
        }
    }
}
