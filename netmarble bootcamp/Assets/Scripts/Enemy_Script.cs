using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class Example : MonoBehaviour
{
    public float radius = 4.0f; // ���� ������
    public LayerMask layerMask; // Ž���� ���̾� ����
    public float speed = 4f;
    private bool IsTarget;
    Vector2 direc;
    Rigidbody2D rb;
    int cnt = 0;
    public bool stun = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!IsTarget)
        {
            StartCoroutine("Idle");
        }
    }

    void Update()
    {
        // ���� ������Ʈ�� ��ġ�� �������� ���� �׷��� �浹�� ����
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        if (rb.velocity.y != 0)
        {
            gameObject.layer = 8;
        }
        else
        {
            gameObject.layer = 6;
        }

        // ������ �ݶ��̴����� ��ȸ�ϸ� �۾� ����
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("asdf");
            if (transform.position.y + 0.5f - hitCollider.transform.position.y < 0.3f && transform.position.y + 0.5f - hitCollider.transform.position.y > -0.3f && cnt++ == 0)
            {
                Debug.Log("fewa");
                IsTarget = true;
                Vector3[] path = new Vector3[3];
                path[0] = transform.position;
                path[1] = new Vector3((transform.position.x + hitCollider.transform.position.x) / 2, transform.position.y + 1f, (transform.position.z + hitCollider.transform.position.z) / 2); // �ְ���
                path[2] = hitCollider.transform.position;

                // ��� Ʈ����
                transform.DOPath(path, 0.75f, PathType.CatmullRom).SetEase(Ease.Linear);
                StartCoroutine("Delay");
            }
        }
    }

    IEnumerator Idle()
    {
        for (; ;)
        {
            if (IsTarget == false)
            {
                if (Random.Range(0, 2) == 1)
                {
                    direc = Vector2.right;
                }
                else
                {
                    direc = Vector2.left;
                }
                rb.velocity = direc;
                yield return new WaitForSeconds(3f);
                rb.velocity = Vector2.zero;
                yield return new WaitForSeconds(3f);
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator Delay()
    {
        IsTarget = false;
        yield return new WaitForSeconds(3f);
        cnt = 0;
    }

    // Gizmos�� �̿��� Scene �信 ���� ������ �ð������� ǥ��
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
