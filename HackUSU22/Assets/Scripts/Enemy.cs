using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
//using System.Numerics;
using UnityEngine;

public class Enemy : BaseEntity
{
    public void OnStart() {

    }

    private void OnDeath()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    /// <summary>
    /// Where this entity wants to go
    /// </summary>
    private Vector2 GetDecsicion() {
        return new Vector2(0f,-1f);
    }
}
