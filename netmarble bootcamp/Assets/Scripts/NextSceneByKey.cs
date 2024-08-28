using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneByKey : MonoBehaviour
{
    public GameObject BG;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                BG.SetActive(true);
                BG.GetComponent<TileRotatorUIReturn>().enabled = true;
            }
        }
    }
}
