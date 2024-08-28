using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using static UnityEngine.GraphicsBuffer;

public class Example1 : MonoBehaviour
{
    public float radius = 8.0f; // 원의 반지름
    public float radius2 = 20f;
    public LayerMask layerMask; // 탐지할 레이어 설정
    public float speed = 4f;
    Rigidbody2D rb;
    public GameObject bullet;
    public static Vector2 dir;
    Collider2D[] hitColliders;
    Collider2D[] hitColliders2;
    public bool stun = false;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("Summon");
    }

    void Update()
    {
        hitColliders2 = Physics2D.OverlapCircleAll(transform.position, radius2, layerMask);
        hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        if (hitColliders.Length == 0)
        {
            anim.SetBool("IsAttack", false);
        }
        if (hitColliders2.Length == 0)
        {
            anim.SetBool("IsRun", false);
        }
        foreach (var hitCollider in hitColliders2)
        {
            if (hitCollider.transform.position.x - transform.position.x >= 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (hitColliders.Length == 0 && (stun == false))
            {
                anim.SetBool("IsRun", true);
                transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, hitCollider.transform.position.x, speed * Time.deltaTime), transform.position.y);
            }
        }
    }

    IEnumerator Summon()
    {
        for (; ; )
        {
            hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
            foreach (var hitCollider in hitColliders)
            {
                if (hitColliders.Length > 0 && (stun == false))
                {
                    anim.SetBool("IsAttack", true);
                    if (transform.position.x - hitCollider.transform.position.x >= 0)
                    {
                        dir = Vector2.left;
                        yield return new WaitForSeconds(0.2f);
                        Instantiate(bullet, new Vector2(transform.position.x - 0.5f, transform.position.y + 0.3f), transform.rotation);
                    }
                    else if (transform.position.x - hitCollider.transform.position.x < 0)
                    {
                        dir = Vector2.right;
                        yield return new WaitForSeconds(0.2f);
                        Instantiate(bullet, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.3f), transform.rotation);
                    }
                    yield return new WaitForSeconds(1f);
                }
                else if (hitColliders.Length == 0)
                {
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return null;
        }
    }

    // Gizmos를 이용해 Scene 뷰에 원의 범위를 시각적으로 표시
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius2);
    }
}
