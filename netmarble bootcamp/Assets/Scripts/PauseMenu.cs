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
        //메인 이동 코드 구현
        //SceneManager.LoadScene("Main");
        Debug.Log("Go To Main Code Add");
    }
    public void Setting()
    {
        //설정창 나타나게 하기
        Debug.Log("Setting Window Add");
    }
}
