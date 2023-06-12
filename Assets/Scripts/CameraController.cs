using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=_QnPY6hw8pA

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform cameraTarget;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        //Vector3 playerPosition = player.position + offset;
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y, -10);
        Vector3 smoothCam = Vector3.Lerp(transform.position, playerPosition, smoothFactor * Time.deltaTime);
        cameraTarget.position = smoothCam;
    }
}
