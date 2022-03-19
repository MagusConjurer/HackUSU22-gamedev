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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MountainUp")
        {
            Camera.main.fieldOfView *= 2;
        } else if(collision.gameObject.name == "MountainDown")
        {
            Camera.main.fieldOfView /= 2;
        }
    }

}


