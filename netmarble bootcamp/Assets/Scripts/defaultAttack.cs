using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultAttack : MonoBehaviour
{
    public static float curtime;
    public static bool isAttack;
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
        if (!Pause.isPause)
        {
            if (curtime <= 0) //ÆòÅ¸ ÄðÅ¸ÀÓ
            {
                isAttack = false;
                if (Input.GetKeyDown(KeyCode.X) && !npc1.talking && !npc2.talking)
                {
                    isAttack = true;
                    int cri = Random.Range(0, 4);
                    if(cri == 0)
                    {
                        ani.SetTrigger("BaseAttack2");
                    }
                    else
                    {
                        ani.SetTrigger("BaseAttack1");
                    }
                    Collider2D[] collider = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + boxSize.x / 2 * (transform.localScale.x >= 0 ? 1 : -1), transform.position.y), boxSize, 0);

                    foreach (Collider2D colliders in collider)
                    {
                        if (colliders.gameObject.CompareTag("Enemy"))
                        {
                            Debug.Log("¶§·È´Ù!");
                            colliders.GetComponent<Rigidbody2D>().velocity = new Vector2(3 * (colliders.transform.position.x - transform.position.x >= 0 ? 1 : -1), 3);
                            Damage = colliders.GetComponent<EnemyHealth>();
                            if (cri == 0)
                            {
                                Damage.curHealth -= 10;
                            }
                            Damage.curHealth -= 20f;
                            if (colliders.GetComponent<Example>() != null)
                            {
                                colliders.GetComponent<Example>().stun = true;
                                StartCoroutine("notStun", colliders);
                            }
                            else if (colliders.GetComponent<Example1>() != null)
                            {
                                colliders.GetComponent<Example1>().stun = true;
                                StartCoroutine("notStun", colliders);
                            }
                            
                        }
                    }
                    curtime = cooltime;
                }
            }
            else //ÆòÅ¸ ÄðÅ¸ÀÓ °¨¼Ò
            { 
                curtime -= Time.deltaTime; 
            }
        }

    }

    IEnumerator notStun(Collider2D collider)
    {
        yield return new WaitForSeconds(0.3f);
        if (collider != null)
        {
            if (collider.GetComponent<Example>() != null)
            {
                collider.GetComponent<Example>().stun = false;
            }
            else if (collider.GetComponent<Example1>() != null)
            {
                collider.GetComponent<Example1>().stun = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + boxSize.x/ 2 * (transform.localScale.x >= 0 ? 1 : -1), transform.position.y), boxSize);
    }
}
