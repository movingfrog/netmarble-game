using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultAttack : MonoBehaviour
{
    public static float curtime;
    public float cooltime = 0.5f;
    EnemyHealth Damage;
    Animator ani;

    public Vector2 boxSize = new Vector2(2,2);

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (curtime <= 0) //ÆòÅ¸ ÄðÅ¸ÀÓ
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                ani.SetBool("BaseAttack", true);
                ani.SetTrigger("BaseAttack1");
                Collider2D[] collider = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + boxSize.x / 2 * (transform.localScale.x >= 0 ? 1 : -1), transform.position.y), boxSize, 0);

                foreach (Collider2D colliders in collider)
                {
                    if (colliders.gameObject.CompareTag("Enemy"))
                    {
                        Debug.Log("¶§·È´Ù!");
                        Damage = colliders.GetComponent<EnemyHealth>();
                        Damage.curHealth -= 20f;
                    }
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    ani.SetTrigger("BaseAttack2");
                    foreach (Collider2D colliders in collider)
                    {
                        if (colliders.gameObject.CompareTag("Enemy"))
                        {
                            Debug.Log("¶§·È´Ù!");
                        }
                    }
                }
                ani.SetBool("BaseAttack", false);
                curtime = cooltime;
            }
        }
        else //ÆòÅ¸ ÄðÅ¸ÀÓ °¨¼Ò
        { 
            curtime -= Time.deltaTime; 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + boxSize.x/ 2 * (transform.localScale.x >= 0 ? 1 : -1), transform.position.y), boxSize);
    }
}
