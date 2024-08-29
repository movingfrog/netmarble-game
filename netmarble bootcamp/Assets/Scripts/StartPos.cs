using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour
{
    public Vector3 Pos;
    public GameObject Player;
    void Start()
    {
        Player.transform.position = Pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
