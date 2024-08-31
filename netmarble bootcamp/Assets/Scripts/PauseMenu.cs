using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject BG;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.isPause)
        {
            BG.SetActive(true);
        }
        else
        {
            BG.SetActive(false);
        }
    }
    public void Resume()
    {
        Pause.isPause = !Pause.isPause;
        Time.timeScale = 1.0f;
    }
    public void GoToMain()
    {
        //���� �̵� �ڵ� ����
        //SceneManager.LoadScene("Main");
        Debug.Log("Go To Main Code Add");
    }
    public void Setting()
    {
        //����â ��Ÿ���� �ϱ�
        Debug.Log("Setting Window Add");
    }
}
