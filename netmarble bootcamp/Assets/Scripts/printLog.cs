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
                    Log.DOText("��? �ڳ״� ������?", 1.2f);
                    break;
                case 1:
                    already = true;
                    Log.text = "";
                    Log.DOText("�� ó�� ���� ����ε��� �մ��ΰǰ�?", 1.2f);
                    break;
                case 2:
                    already = true;
                    Log.text = "";
                    Log.DOText("����, �� ������ ��¥ �������� �մ��� �Ա���.", 1.2f);
                    break;
                case 3:
                    already = true;
                    Log.text = "";
                    Log.DOText("�ڳ�, Ȥ�� �� ����� �����Ϸ� �°ǰ�?", 1.2f);
                    break;
                case 4:
                    already = true;
                    Log.text = "";
                    Log.DOText("��, �𸣴� �� ���� ��ġ�α�.", 1.2f);
                    break;
                case 5:
                    already = true;
                    Log.text = "";
                    Log.DOText("�ϱ�, ���� �޺��Ƹ����� ������ �Ͼ �ٵ� �𸣴���.", 1.2f);
                    break;
                case 6:
                    already = true;
                    Log.text = "";
                    Log.DOText("�� ���� �迡 �ѹ� �˷�����. �̰� ����̾�.", 1.2f);
                    break;
                case 7:
                    already = true;
                    Log.text = "";
                    Log.DOText("������� ����� ���긮�� ��������, ������� �� ������ ���ϰ� �ƴ϶� �ϴ��� ���̴� ���󿡼� ��Ҿ���.", 1.2f);
                    break;
                case 8:
                    already = true;
                    Log.text = "";
                    Log.DOText("�Ƹ��ٿ� ǳ��, ���� õ��, ��ſ� ���̵��� �����Ҹ���,", 1.2f);
                    break;
                case 9:
                    already = true;
                    Log.text = "";
                    Log.DOText("������ �� ������ �͵��� ������� �� �Ѽ����̾���.", 1.2f);
                    break;
                case 10:
                    already = true;
                    Log.text = "";
                    Log.DOText("��� ��, ���ڱ� �ϴÿ��� ������ �� ���� ������ �鸮�� �ϴÿ��� ���� ������ ��������.", 1.2f);
                    break;
                case 11:
                    already = true;
                    Log.text = "";
                    Log.color = Color.red;
                    Log.fontSize += 10;
                    Log.DOText("���󳢸� �������� �����Ѱ���.", 1.2f);
                    break;
                case 12:
                    already = true;
                    Log.text = "";
                    Log.color = Color.white;
                    Log.fontSize -= 10;
                    Log.DOText("�׷��� ������� ó���ϰ� �׾����.", 1.2f);
                    break;
                case 13:
                    already = true;
                    Log.text = "";
                    Log.DOText("���� ������� ��� ���� ���Ϸ� �ǽ��� �����߰�", 1.2f);
                    break;
                case 14:
                    already = true;
                    Log.text = "";
                    Log.DOText("���Ͽ��� ������ ����鳢�� ��ġ�鼭 �� ������ �����������.", 1.2f);
                    break;
                case 15:
                    already = true;
                    Log.text = "";
                    Log.DOText("��, ���� ����� �� ���̶� ���� �ڼ��� ���� �� ����.", 1.2f);
                    break;
                case 16:
                    already = true;
                    Log.text = "";
                    Log.DOText("������ ���� ���� ����� ���� ���� �� �� ���ҽ��Ѽ� ������.", 1.2f);
                    break;
                case 17:
                    already = true;
                    Log.text = "";
                    Log.DOText("�ƹ�ư, �� �������� ���ٰ� ���ð�. ���Ÿ��� ������ ���̾�.", 1.2f);
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
