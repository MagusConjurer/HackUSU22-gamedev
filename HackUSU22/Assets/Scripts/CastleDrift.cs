using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDrift : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D box;
    float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
            speed = 2f;
    }
}
