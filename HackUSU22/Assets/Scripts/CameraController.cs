using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float cameraOffsetY = 10;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + cameraOffsetY, transform.position.z);
        if (player.position.x > 160 && player.position.x < 240)
        {
            Camera.main.orthographicSize = 10.0f;
        }
        else
            Camera.main.orthographicSize = 8.0f;
    }


}


