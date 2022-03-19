using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    public static List<GameObject> tiles;

    private void Start()
    {
        tiles = new List<GameObject>();
    }

    //private void Update()
    //{
        //foreach(GameObject o in tiles)
        //{
        //    float x = o.transform.parent.position.x;
        //    o.transform.position = new Vector3(x, -2);
        //}
    //}

    public static void generateFloatingPlots()
    {

    }

    public static void generateGround(Transform curr, float width)
    {
        Vector2 parent = (Vector2)curr.position;

        GameObject wall = new GameObject("ground_1");
        wall.tag = "ground";
        wall.transform.parent = curr.transform;
        wall.transform.position = new Vector2(parent.x + 39, -2);
        wall.transform.localScale = new Vector3(width / 1.3f, 1);

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
        wrb.simulated = true;
        wrb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

        tiles.Add(wall);

    }
}
