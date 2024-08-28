using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TileRotatorUIReturn : MonoBehaviour
{
    public float rotationDuration = 1f;  // ȸ�� �ð�
    public float delayBetweenTiles = 0.1f;  // Ÿ�� ���� ������
    public string SceneName;
    public float CoolTime;

    void Start()
    {
        // ��� �ڽ� Ÿ��(UI Image)�� ���� ȸ�� �ִϸ��̼��� �����մϴ�.
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tile = transform.GetChild(i);
            float delay = i * delayBetweenTiles;

            // Z���� �������� 180�� ȸ��
            tile.DORotate(new Vector3(0, 0, 0), rotationDuration, RotateMode.Fast)
                .SetDelay(delay)
                .SetEase(Ease.InOutQuad);
        }

        // ��� Ÿ���� ȸ���� �Ŀ� �� ��ȯ
        Invoke("LoadNextScene", rotationDuration + delayBetweenTiles * transform.childCount + CoolTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
