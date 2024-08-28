using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lap3Manager : MonoBehaviour
{
    private int MapChange = 1;
    public List<GameObject> EnemyList1 = new List<GameObject>();
    public List<GameObject> EnemyList2 = new List<GameObject>();
    public List<GameObject> EnemyList3 = new List<GameObject>();
    public GameObject[] WaveEnemies;

    public GameObject[] Siren;

    private void Awake()
    {
        MapChange = 1;
    }

    private void Update()
    {
        if (MapChange == 1)
        {
            for (int i = EnemyList1.Count - 1; i >= 0; i--)
            {
                if (EnemyList1[i] == null || !EnemyList1[i].activeInHierarchy)
                {
                    EnemyList1.RemoveAt(i);
                }
            }
        }
        else if(MapChange == 2)
        {
            for (int i = EnemyList2.Count - 1; i >= 0; i--)
            {
                if (EnemyList2[i] == null || !EnemyList2[i].activeInHierarchy)
                {
                    EnemyList2.RemoveAt(i);
                }
            }
        }
        else if(MapChange == 3)
        {
            for (int i = EnemyList3.Count - 1; i >= 0; i--)
            {
                if (EnemyList3[i] == null || !EnemyList3[i].activeInHierarchy)
                {
                    EnemyList3.RemoveAt(i);
                }
            }
        }
        if(EnemyList1.Count == 0&&MapChange == 1)
        {
            DelayMob();
            for(int i = 0; i < 3; i++)
            {
                StartCoroutine("Wave");
            }
        }
        else if(EnemyList2.Count == 0&&MapChange == 2){
            DelayMob();
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine("Wave");
            }
        }
        else if(EnemyList3.Count == 0&&MapChange == 3)
        {
            DelayMob();
        }
    }

    IEnumerator Wave()
    {
        for(int i = 0; i < Siren.Length; i++)
        {
            Siren[i].SetActive(true);
        }
        WaveEnemies[MapChange-2].SetActive(false);
        WaveEnemies[MapChange-1].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < Siren.Length; i++)
        {
            Siren[i].SetActive(false);
        }
    }

    public void DelayMob()
    {
        MapChange++;
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MapChange == 3)
            {
                SceneManager.LoadScene("Vilage");
            }
        }
    }
}
