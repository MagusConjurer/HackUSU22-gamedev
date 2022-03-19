using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject player;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerXDir = -player.GetComponent<Rigidbody2D>().velocity.x;
        if (rb.velocity.x != playerXDir)
            rb.velocity = new Vector2(playerXDir, 0);

        // if beyond outer threshold tp image to reset position
        if (transform.position.x < -width && tag == "Tapestry")
        {
            Vector2 resetPos = new Vector2(2f * width, 0);
            transform.position = (Vector2)transform.position + resetPos;
        }

    }
}
