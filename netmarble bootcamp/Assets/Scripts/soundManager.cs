using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    public static float saveVolume = 1f;
    Slider soundSlider;


    private void Awake()
    {
        soundSlider = GameObject.Find("Slider").GetComponent<Slider>();
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
            soundSlider = GameObject.Find("Slider").GetComponent<Slider>();
        }
        else if (scene.name == "Village")
        {
            soundSlider = GameObject.Find("Slider").GetComponent<Slider>();
        }
        else if (scene.name == "Tunnel" || scene.name == "Tunnel_2")
        {
            GameObject.Find("TunnelBGM").GetComponent<AudioSource>().Play();
            soundSlider = GameObject.Find("Slider").GetComponent<Slider>();
        }
        soundSlider.value = saveVolume;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void FixedUpdate()
    {
        saveVolume = GameObject.Find("mainBGM").GetComponent<AudioSource>().volume = GameObject.Find("LabBGM").GetComponent<AudioSource>().volume = GameObject.Find("TunnelBGM").GetComponent<AudioSource>().volume = soundSlider.value;
    }
}
