using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D backCollider;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        backCollider = GetComponent<BoxCollider2D>();

        width = backCollider.size.x;
        backCollider.enabled = false;

        TileGeneration.generateTile(transform, width);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(PlayerController.getDirection(), 0);
        // if below/above outer threshold tp image to reset position
        if(transform.position.x < -width)
        {
            Vector2 resetPos = new Vector2(2f * width, 0);
            transform.position = (Vector2)transform.position + resetPos;
        }
        foreach(GameObject o in TileGeneration.tiles)
        {
            o.transform.position = new Vector3(transform.position.x+38, -2);
        }
    }
}
