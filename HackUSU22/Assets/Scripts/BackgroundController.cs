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

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2()
    }
}
