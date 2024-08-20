using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using static UnityEngine.GraphicsBuffer;

public class Example : MonoBehaviour
{
    public float radius = 4.0f; // 원의 반지름
    public LayerMask layerMask; // 탐지할 레이어 설정
    public float speed = 4f;
    private bool IsTarget;
    Vector2 direc;
    Rigidbody2D rb;
    int cnt = 0;

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
        IsTarget = false;
        // 현재 오브젝트의 위치를 기준으로 원을 그려서 충돌을 감지
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        // 감지된 콜라이더들을 순회하며 작업 수행
        foreach (var hitCollider in hitColliders)
        {
            IsTarget = true;


            if (transform.position.y - hitCollider.transform.position.y < 0.3f && transform.position.y - hitCollider.transform.position.y > -0.3f && cnt++ == 0)
            {
                Vector3[] path = new Vector3[3];
                path[0] = transform.position;
                path[1] = new Vector3((transform.position.x + hitCollider.transform.position.x) / 2, transform.position.y + 1f, (transform.position.z + hitCollider.transform.position.z) / 2); // 최고점
                path[2] = hitCollider.transform.position;

                // 경로 트위닝
                transform.DOPath(path, 0.75f, PathType.CatmullRom).SetEase(Ease.Linear);
                StartCoroutine("Delay");
            }
        }
    }

    IEnumerator Idle()
    {
        for (; ;)
        {
            if (cnt == 0)
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
        yield return new WaitForSeconds(3f);
        cnt = 0;
    }

    // Gizmos를 이용해 Scene 뷰에 원의 범위를 시각적으로 표시
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
