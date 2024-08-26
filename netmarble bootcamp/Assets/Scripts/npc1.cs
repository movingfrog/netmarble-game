using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class npc1 : MonoBehaviour
{
    Collider2D[] hitColliders;
    public GameObject button;
    RectTransform UI;
    public static bool talking = false;
    public static Camera mainCamera;
    public LayerMask layerMask;
    Vector3 npcPosition;
    public GameObject panel;

    private void Awake()
    {
        mainCamera = Camera.main;
        npcPosition = transform.position;
        npcPosition.z = -10f;
        UI = button.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f, layerMask);
        UI.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z));
        if (hitColliders.Length > 0 && (talking == false))
        {
            button.SetActive(true);
        }
        if (hitColliders.Length == 0 || (talking == true))
        {
            button.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F) &&  hitColliders.Length > 0 && (talking == false))
        {
            text();
        }
    }

    public void text()
    {
        talking = true;
        mainCamera.transform.DOMove(npcPosition, 1f);
        DOTween.To(() => mainCamera.orthographicSize, x => mainCamera.orthographicSize = x, 3f, 1f).SetEase(Ease.OutSine);
        panel.SetActive(true);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
