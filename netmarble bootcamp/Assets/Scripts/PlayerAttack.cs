using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attckObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            attckObject.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.X))
        {
            attckObject.SetActive(false);
        }
    }
}
