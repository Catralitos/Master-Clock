using System;
using System.Collections;
using System.Collections.Generic;
using Chronos;
using UnityEngine;

public class VerticalMovingPlatform : NonStaticPlatform
{
    public float range;

    public bool startUp;

    private bool _goingDown;
    private float _startY;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        _goingDown = startUp;
        _startY = transform.position.y;
        Vector3 dir = startUp ? Vector3.up : Vector3.down;
        transform.position += dir * range;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentY = transform.position.y;
        if ((currentY >= _startY + range && !_goingDown) || (currentY <= _startY - range && _goingDown))
        {
            _goingDown = !_goingDown;
        }

        Vector3 dir = _goingDown ? Vector3.down : Vector3.up;
        Vector2 targetVelocity = dir * moveSpeed * time.fixedDeltaTime ;
        body.velocity = Vector2.SmoothDamp(body.velocity, targetVelocity, ref velocity, movementSmoothing);
    }
}