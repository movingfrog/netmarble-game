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
                if (Input.GetKeyDown(KeyCode.X))
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
                            Damage = colliders.GetComponent<EnemyHealth>();
                            if (cri == 0)
                            {
                                Damage.curHealth -= 10;
                            }
                            Damage.curHealth -= 20f;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + boxSize.x/ 2 * (transform.localScale.x >= 0 ? 1 : -1), transform.position.y), boxSize);
    }
}
