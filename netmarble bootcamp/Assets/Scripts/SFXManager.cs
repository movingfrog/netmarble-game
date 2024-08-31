using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    Slider soundSlider;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SFXManager").Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
        soundSlider = GameObject.FindGameObjectWithTag("SFX").GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        GameObject.Find("PullSFX").GetComponent<AudioSource>().volume = GameObject.Find("AttackSFX").GetComponent<AudioSource>().volume = GameObject.Find("DamageSFX").GetComponent<AudioSource>().volume = GameObject.Find("TSFX").GetComponent<AudioSource>().volume = soundSlider.value;
    }
}
