using System.Collections;
using System.Collections.Generic;
using UnityEditor.VisionOS;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void summonPanel()
    {
        panel.SetActive(true);
    }

    public void hidePanel()
    {
        panel.SetActive(false);
    }
}
