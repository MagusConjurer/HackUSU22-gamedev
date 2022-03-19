using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void generateTile(GameObject curr)
    {
        Vector2 parent = curr.transform.position;

        GameObject wall = new GameObject("wall_1");
        wall.transform.parent = curr.transform;
        wall.transform.position = new Vector2(parent.x + 50, -2);
        wall.transform.localScale = new Vector3(20, 1);

        SpriteRenderer wallSp = wall.AddComponent<SpriteRenderer>();
        Texture2D tex = new Texture2D(128, 128);

        wallSp.sprite = Sprite.Create(tex, new Rect(0.0f,0.0f, tex.width, tex.height), new Vector2(2.5f, 2.5f));
        wallSp.sortingOrder = 1;
        wallSp.color = Color.green;

        BoxCollider2D box =  wall.AddComponent<BoxCollider2D>();
        box.enabled = true;
        box.size.Set(20, 1);

        Rigidbody2D wrb = wall.AddComponent<Rigidbody2D>();
        wrb.gravityScale = 0f;
        wrb.simulated = false;
    }
}
