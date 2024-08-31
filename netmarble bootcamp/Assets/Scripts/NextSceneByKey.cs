using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneByKey : MonoBehaviour
{
    public GameObject BG;
    public Vector2 Size;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, Size, 0);
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach(Collider2D col in cols)
            {
                if (col.gameObject.CompareTag("Player"))
                {
                    BG.SetActive(true);
                    BG.GetComponent<TileRotatorUIReturn>().enabled = true;
                }
            }
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, Size);
    }
}
