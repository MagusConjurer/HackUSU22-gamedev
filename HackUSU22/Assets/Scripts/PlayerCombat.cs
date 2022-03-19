using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerCombat : Combat
{
    private float nextAttackTime = 0f;
    private bool chargingAttack = false;

    // Update is called once per frame
    void Update()
    {
        // Cancels attack
        if (Input.GetButtonDown("Fire2")) {
            chargingAttack = false;
        }

        if (Input.GetButtonDown("Fire1"))
        { 
 

            // if this attack is newly called
            if (!chargingAttack) {
                AttackPrepare();
                nextAttackTime = Time.time + attackRate;
            }

            chargingAttack = true;
        }
        else if (Input.GetButtonUp("Fire1")) {
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
        // TODO: Play attack anim
        animator.SetTrigger("Attack Prepare");
    }

    private void AttackRelease()
    {
        Debug.Log("Attack Release");
        chargingAttack = false;
        animator.SetTrigger("Attack Release");
    }

    public void AttackSwing() {
        Debug.Log("Attack Swing()");
        // Detect in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);
        // Apply damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}
