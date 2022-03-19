using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : Combat
{
    private float nextAttackTime = 0;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);

        if (Time.time > nextAttackTime && hitPlayers.Length > 0)
        {
            Attack(hitPlayers);
            nextAttackTime = Time.time + attackRate;
        }
    }

    private void Attack(Collider2D[] hitPlayers)
    {
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }
    }
}
