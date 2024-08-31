using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject BG;
    public GameObject panel;
    public Button[] buttons;
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
        panel.SetActive(true);
        panel.transform.SetAsLastSibling();
        buttons[0].interactable = false;
        buttons[1].interactable = false;
        buttons[2].interactable = false;
    }

    public void GoToBG()
    {
        panel.SetActive(false);
        buttons[0].interactable = true;
        buttons[1].interactable = true;
        buttons[2].interactable = true;
    }
}
