using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using static UnityEngine.GraphicsBuffer;

public class Example1 : MonoBehaviour
{
    public float radius = 8.0f; // ���� ������
    public float radius2 = 20f;
    public LayerMask layerMask; // Ž���� ���̾� ����
    public float speed = 4f;
    Rigidbody2D rb;
    public GameObject bullet;
    public static Vector2 dir;
    Collider2D[] hitColliders;
    Collider2D[] hitColliders2;
    public bool stun = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Summon");
    }

    void Update()
    {
        hitColliders2 = Physics2D.OverlapCircleAll(transform.position, radius2, layerMask);
        hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        foreach (var hitCollider in hitColliders2)
        {
            if (hitColliders.Length == 0)
                transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, hitCollider.transform.position.x, speed * Time.deltaTime), transform.position.y);
        }
    }

    IEnumerator Summon()
    {
        for (; ; )
        {
            hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
            foreach (var hitCollider in hitColliders)
            {
                if (hitColliders.Length > 0)
                {
                    if (transform.position.x - hitCollider.transform.position.x >= 0)
                    {
                        dir = Vector2.left;
                        Instantiate(bullet, new Vector2(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    }
                    else if (transform.position.x - hitCollider.transform.position.x < 0)
                    {
                        dir = Vector2.right;
                        Instantiate(bullet, new Vector2(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    }
                    yield return new WaitForSeconds(0.3f);
                }
                else if (hitColliders.Length == 0)
                {
                    yield return new WaitForSeconds(0.3f);
                }
            }
            yield return null;
        }
    }

    // Gizmos�� �̿��� Scene �信 ���� ������ �ð������� ǥ��
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius2);
    }
}
