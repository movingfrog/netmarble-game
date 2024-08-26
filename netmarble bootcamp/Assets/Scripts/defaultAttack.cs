using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultAttack : MonoBehaviour
{
    public static float curtime;
    public float cooltime = 0.5f;

    public Vector2 boxSize = new Vector2(2,2);

    private void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Collider2D[] collider = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + boxSize.x / 2 * (transform.localScale.x >= 0 ? 1 : -1), transform.position.y), boxSize, 0);

                foreach (Collider2D colliders in collider)
                {
                    if (colliders.gameObject.CompareTag("Enemy"))
                    {
                        Debug.Log("���ȴ�!");
                    }
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    foreach (Collider2D colliders in collider)
                    {
                        if (colliders.gameObject.CompareTag("Enemy"))
                        {
                            Debug.Log("���ȴ�!");
                        }
                    }
                }
                curtime = cooltime;
            }
        }
        else
            curtime -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + boxSize.x/ 2 * (transform.localScale.x >= 0 ? 1 : -1), transform.position.y), boxSize);
    }
}
