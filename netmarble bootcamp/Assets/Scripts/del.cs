using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class del : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 0.4f);
    }
}
