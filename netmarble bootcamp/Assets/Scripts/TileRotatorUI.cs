using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class TileRotatorUI : MonoBehaviour
{
    public float rotationDuration = 1f;  // ȸ�� �ð�
    public float delayBetweenTiles = 0.1f;  // Ÿ�� ���� ������
    public static bool LoadSceneEnd = false;

    void Start()
    {
        // ��� �ڽ� Ÿ��(UI Image)�� ���� ȸ�� �ִϸ��̼��� �����մϴ�.
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tile = transform.GetChild(i);
            float delay = i * delayBetweenTiles;

            // Z���� �������� 180�� ȸ��
            tile.DORotate(new Vector3(90, 0, 0), rotationDuration, RotateMode.Fast)
                .SetDelay(delay)
                .SetEase(Ease.InOutQuad);
        }

        // ��� Ÿ���� ȸ���� �Ŀ� �� ��ȯ
        Invoke("SceneStart", rotationDuration + delayBetweenTiles * transform.childCount);
    }

    public void SceneStart()
    {
        LoadSceneEnd = true;
        GetComponent<TileRotatorUI>().enabled = false;
        gameObject.SetActive(false);
    }
}
