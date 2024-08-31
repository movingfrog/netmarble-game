using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public static float saveVolume = 1f;
    Slider soundSlider;
    GameObject panel;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SFXManager").Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
        soundSlider = GameObject.FindGameObjectWithTag("SFX").GetComponent<Slider>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "mainUI" && scene.name != "GameOver" && scene.name != "End")
        {
            soundSlider = GameObject.FindGameObjectWithTag("SFX").GetComponent<Slider>();
            panel = GameObject.FindGameObjectWithTag("panel");
            panel.SetActive(false);
        }
        if (soundSlider != null)
        {
            soundSlider.value = saveVolume;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void FixedUpdate()
    {
        saveVolume = GameObject.Find("PullSFX").GetComponent<AudioSource>().volume = GameObject.Find("AttackSFX").GetComponent<AudioSource>().volume = GameObject.Find("DamageSFX").GetComponent<AudioSource>().volume = GameObject.Find("TSFX").GetComponent<AudioSource>().volume = soundSlider.value;
    }
}
