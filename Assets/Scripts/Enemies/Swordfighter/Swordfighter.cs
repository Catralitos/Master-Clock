using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class Swordfighter : EnemyBase<Swordfighter>
{
    public float moveSpeed;
    
    public float sightDistance;
    public float movementSmoothing = 0.05f;
    public float holdPositionTime;
    public float horizontalRange;
    public float attackRange;
    
    public bool facingRight = true;

    public LayerMask groundMask;
    public LayerMask playerMask;
    
    public CapsuleCollider2D attackBox;
    [HideInInspector] public Rigidbody2D rb;

    [HideInInspector] public float currentPatrolAnchor;
    [HideInInspector] public Vector2 velocity;

    protected override void Start()
    {
        base.Start();
        if (!started)
        {
            rb = GetComponent<Rigidbody2D>();
            state = SwordfighterIdle.Create(this);
            currentPatrolAnchor = transform.position.x;
            started = true;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (started) state = SwordfighterIdle.Create(this);
    }
    
}