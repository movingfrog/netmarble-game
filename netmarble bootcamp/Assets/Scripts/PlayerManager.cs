using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static float PlayerHP = 100;

    public static void takeDamage(float  damage)
    {
        PlayerHP -= damage;
    }
}
