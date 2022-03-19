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
        if (Time.time > nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }
        }
        //if (Input.GetButtonDown("Fire1"))
        //{ 
        //    // if this attack is newly called
        //    if (!attackHeld) {
        //        AttackPrepare();
        //        nextAttackTime = Time.time + attackRate;
        //    }
        //    attackHeld = true;
        //}
        //if (Input.GetButtonUp("Fire1")) {
        //    attackHeld = false;
        //    // If released after attack rate
        //    if(Time.time > nextAttackTime)
        //    {
        //        AttackRelease();
        //        nextAttackTime = Time.time + 1f / attackRate;
        //    }
        //    // Released before attack rate over
        //    else {
        //        Invoke("AttackRelease", Time.time - nextAttackTime);
        //    }
        //}
    }

    private void Attack()
    {
        animator.SetTrigger("Attack Prepare");
        GetComponent<PlayerController>().PlayRandomClash();
        // Detect in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);
        // Apply damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        animator.SetTrigger("Attack Release");
    }

    //private void AttackPrepare()
    //{
    //    animator.SetTrigger("Attack Prepare");
    //}

    //private void AttackRelease()
    //{
    //    Debug.Log("Attack Release");
    //    animator.SetTrigger("Attack Release");
    //    GetComponent<PlayerController>().PlayRandomClash();
    //}

    //public void AttackSwing() {
    //    Debug.Log("Attack Swing()");
    //    GetComponent<PlayerController>().PlayRandomClash();
    //    // Detect in range
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);
    //    // Apply damage
    //    foreach(Collider2D enemy in hitEnemies)
    //    {
    //        enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
    //    }
    //}
}
