using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSpawnPos : MonoBehaviour
{
    public Vector3 SpawnPos;
    void Start()
    {
        transform.position = SpawnPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
