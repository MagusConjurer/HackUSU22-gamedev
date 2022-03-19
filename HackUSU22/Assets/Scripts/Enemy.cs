using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//using System.Numerics;
using UnityEngine;

public class Enemy : BaseEntity
{
    public Transform player;
    public float accuracy;
    public float followRange = 10;
    protected override void OnStart() 
    {
        if(player == null)
        {
            player = GameObject.Find("Player").transform;
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        StandardSpawning spawner = GameObject.FindGameObjectWithTag("StandardSpawner").GetComponent<StandardSpawning>();
        spawner.DestroyEnemy(gameObject);
    }

    /// <summary>
    /// Where this entity wants to go
    /// </summary>
    protected override Vector2 GetDecision() {
        Vector3 direction = player.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        if (direction.magnitude > accuracy && TargetInRange())
        {
            if(direction.x > 0)
                sprite.flipX = true;
            return new Vector2(direction.x, direction.y).normalized;
        }
        else
        {
            return new Vector2(0f, 0f);
        }
    }

    private bool TargetInRange()
    {
        if (Vector2.Distance(transform.position, player.position) < followRange)
        {
            return true;
        }

        return false;
    }
}
