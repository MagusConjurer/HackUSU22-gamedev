using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerCombat : Combat
{

    private float nextAttackTime = 0f;

    protected override void OnStart() {
        attackRange = 0.3f;
        attackDamage = 25;
        attackRate = 0.2f;
    }

    private bool attackHeld = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
            // if this attack is newly called
            if (!attackHeld) {
                AttackPrepare();
                nextAttackTime = Time.time + attackRate;
            }
            attackHeld = true;
        }
        if (Input.GetButtonUp("Fire1")) {
            // If released after attack rate
            if(Time.time > nextAttackTime)
            {
                AttackRelease();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            // Released before attack rate over
            else {
                Invoke("AttackRelease", Time.time - nextAttackTime);
            }
        }
    }

    private void AttackPrepare()
    {
        animator.SetTrigger("Attack Prepare");
    }

    private void AttackRelease()
    {
        attackHeld = false;
        Debug.Log("Attack Release");
        animator.SetTrigger("Attack Release");
        GetComponent<PlayerController>().PlayRandomClash();
    }

    public void AttackSwing() {
        Debug.Log("Attack Swing()");
        GetComponent<PlayerController>().PlayRandomClash();
        // Detect in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);
        // Apply damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}
