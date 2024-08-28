using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class TileRotatorUI : MonoBehaviour
{
    public float rotationDuration = 1f;  // 회전 시간
    public float delayBetweenTiles = 0.1f;  // 타일 간의 딜레이
    public static bool LoadSceneEnd = false;

    void Start()
    {
        // 모든 자식 타일(UI Image)에 대해 회전 애니메이션을 적용합니다.
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tile = transform.GetChild(i);
            float delay = i * delayBetweenTiles;

            // Z축을 기준으로 180도 회전
            tile.DORotate(new Vector3(90, 0, 0), rotationDuration, RotateMode.Fast)
                .SetDelay(delay)
                .SetEase(Ease.InOutQuad);
        }

        // 모든 타일이 회전한 후에 씬 전환
        Invoke("SceneStart", rotationDuration + delayBetweenTiles * transform.childCount);
    }

    public void SceneStart()
    {
        LoadSceneEnd = true;
        GetComponent<TileRotatorUI>().enabled = false;
        gameObject.SetActive(false);
    }
}
