using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject Bg;
    //public GameObject canvas;
    void Start()
    {
        Bg.transform.SetAsLastSibling();
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && TileRotatorUI.LoadSceneEnd)
        {            
            isPause = !isPause;
            //.transform.SetParent(canvas.transform, false);
            if (!isPause)
            {
                Debug.Log("Resume!");
                Time.timeScale = 1f;
            }
            else
            {
                Debug.Log("Pause!");
                Time.timeScale = 0f;
            }

        }
    }
}
