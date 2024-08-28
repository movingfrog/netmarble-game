using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPause = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            isPause = !isPause;
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
