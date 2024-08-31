using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject BG;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !NextSceneByKey.existEnemy)
        {
            BG.SetActive(true);
            BG.GetComponent<TileRotatorUIReturn>().enabled = true;
        }
    }
}
