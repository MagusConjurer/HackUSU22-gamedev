using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public LayerMask targetLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 0.5f;
    public int attackDamage = 25;

    protected Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    protected virtual void OnStart() {}

    // Debug method to visualize the range of the attack
    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
