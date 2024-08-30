using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text Text;
    public GameObject button;

    private void Awake()
    {
        Text.DOText("Game Over", 2f);
        StartCoroutine("enableButton");
    }

    IEnumerator enableButton()
    {
        yield return new WaitForSeconds(2.5f);
        button.gameObject.SetActive(true);
    }

    public void toMain()
    {
        SceneManager.LoadScene("mainUI");
    }
}
