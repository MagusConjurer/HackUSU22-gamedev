using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDrift : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.velocity = new Vector2(-10f, 0);
    }
}
