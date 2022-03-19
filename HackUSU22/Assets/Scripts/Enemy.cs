using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
//using System.Numerics;
using UnityEngine;

public class Enemy : BaseEntity
{
    protected override void OnStart() {
    }

    protected override void OnDeath()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    /// <summary>
    /// Where this entity wants to go
    /// </summary>
    protected override Vector2 GetDecision() {
        return new Vector2(0f,-1f);
    }
}
