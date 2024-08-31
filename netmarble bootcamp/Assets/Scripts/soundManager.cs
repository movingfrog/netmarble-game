using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    Slider soundSlider;
    GameObject panel;
    private void Awake()
    {
        soundSlider = FindObjectOfType<Slider>();
        panel = GameObject.FindGameObjectWithTag("panel");
        panel.SetActive(false);
        if (GameObject.FindGameObjectsWithTag("BgmManager").Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject.Find("mainBGM").GetComponent<AudioSource>().Stop();
        GameObject.Find("LabBGM").GetComponent<AudioSource>().Stop();
        GameObject.Find("TunnelBGM").GetComponent<AudioSource>().Stop();
        if (scene.name == "mainUI")
        {
            GameObject.Find("mainBGM").GetComponent<AudioSource>().Play();
        }
        else if (scene.name == "Lab" || scene.name == "Lab_2" || scene.name == "Lab_3")
        {
            GameObject.Find("LabBGM").GetComponent<AudioSource>().Play();
        }
        else if (scene.name == "Tunnel" || scene.name == "Tunnel_2")
        {
            GameObject.Find("TunnelBGM").GetComponent<AudioSource>().Play();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void FixedUpdate()
    {
        GameObject.Find("mainBGM").GetComponent<AudioSource>().volume = GameObject.Find("LabBGM").GetComponent<AudioSource>().volume = GameObject.Find("TunnelBGM").GetComponent<AudioSource>().volume = soundSlider.value;
    }

    public void panelSummon()
    {
        panel.SetActive(true);
    }

    public void panelHide()
    {
        panel.SetActive(false);
    }
}
