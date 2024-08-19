using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class Example : MonoBehaviour
{
    public float radius = 4.0f; // 원의 반지름
    public LayerMask layerMask; // 탐지할 레이어 설정
    public float speed = 4f;
    private bool IsTarget;
    Vector2 direc;
    Rigidbody2D rb;

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
            // 적의 현재 위치 가져오기
            Vector3 enemyPosition = transform.position;

            // 플레이어의 X좌표를 목표로 설정
            float targetX = hitCollider.transform.position.x;

            // 적이 목표 X좌표로 이동하도록 계산 (현재 위치와 목표 위치 간의 선형 보간)
            float newX = Mathf.MoveTowards(enemyPosition.x, targetX, speed * Time.deltaTime);

            // 적의 새로운 위치 설정 (X축만 변경하고 Y축과 Z축은 유지)
            transform.position = new Vector3(newX, enemyPosition.y, enemyPosition.z);
        }
    }

    IEnumerator Idle()
    {
        for (; !IsTarget;)
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
    }

    // Gizmos를 이용해 Scene 뷰에 원의 범위를 시각적으로 표시
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
