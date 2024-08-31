using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Effect : MonoBehaviour
{
    EnemyHealth Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("���ȴ�!");
            Damage = collision.GetComponent<EnemyHealth>();
            Damage.curHealth -= PlayerAttack1.damage;
            GameObject.Find("TSFX").GetComponent<AudioSource>().Play();
        }
    }
}
