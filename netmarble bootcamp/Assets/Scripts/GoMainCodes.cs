using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoMainCodes : MonoBehaviour
{
    public GameObject BG;

    private void Start()
    {
        BG.SetActive(false);
    }

    public void GoMainCode()
    {
        BG.SetActive(true);
        BG.GetComponent<Image>().DOColor(new Color(0, 0, 0, 1), 1.2f).SetUpdate(true);

        // 코루틴 시작
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        Time.timeScale = 1f;
        Debug.Log("MainReturn");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("mainUI");
    }
}
