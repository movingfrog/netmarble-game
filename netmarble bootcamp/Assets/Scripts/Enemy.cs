using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackDamage = 3;
    public int speed = 5;
    public float stopDistance;
    public static Transform target;
    public static bool IsPlayer;



    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.takeDamage(attackDamage);
            Debug.Log(PlayerManager.PlayerHP);
        }
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stopDistance && IsPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime); 
        }
    }
}
