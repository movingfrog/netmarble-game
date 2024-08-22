using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public float CameraYPos;
    public GameObject player;

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector2(dir.x * cameraSpeed * Time.deltaTime, (dir.y+CameraYPos) * cameraSpeed * Time.deltaTime);
        this.transform.Translate(moveVector);
    }
}
