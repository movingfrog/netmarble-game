using UnityEditor.Rendering;
using UnityEngine;

public class Example : MonoBehaviour
{
    public float radius = 4.0f; // ���� ������
    public LayerMask layerMask; // Ž���� ���̾� ����
    public float speed = 4f;

    void Update()
    {
        // ���� ������Ʈ�� ��ġ�� �������� ���� �׷��� �浹�� ����
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        // ������ �ݶ��̴����� ��ȸ�ϸ� �۾� ����
        foreach (var hitCollider in hitColliders)
        {
            // ���� ���� ��ġ ��������
            Vector3 enemyPosition = transform.position;

            // �÷��̾��� X��ǥ�� ��ǥ�� ����
            float targetX = hitCollider.transform.position.x;

            // ���� ��ǥ X��ǥ�� �̵��ϵ��� ��� (���� ��ġ�� ��ǥ ��ġ ���� ���� ����)
            float newX = Mathf.MoveTowards(enemyPosition.x, targetX, speed * Time.deltaTime);

            // ���� ���ο� ��ġ ���� (X�ุ �����ϰ� Y��� Z���� ����)
            transform.position = new Vector3(newX, enemyPosition.y, enemyPosition.z);
        }
    }

    // Gizmos�� �̿��� Scene �信 ���� ������ �ð������� ǥ��
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
