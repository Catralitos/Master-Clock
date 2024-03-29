using System;
using UnityEngine;

public class GunnerPatrol: GunnerState
{
    private Vector2 _patrolLeftPoint;
    private Vector2 _patrolRightPoint;

    public static GunnerPatrol Create(Gunner target)
    {
        GunnerPatrol state = GunnerState.Create<GunnerPatrol>(target);
        return state;
    }

    public override void StateStart()
    {
        base.StateStart();
        _patrolLeftPoint = (Vector2) target.currentPatrolAnchor + Vector2.left * target.horizontalRange;
        _patrolRightPoint = (Vector2) target.currentPatrolAnchor + Vector2.right * target.horizontalRange;
        Flip();
        animator.SetBool("Stopped", false);
        animator.SetBool("Patrolling", true);
        animator.SetBool("Chasing", false);
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        if (target.facingRight)
        {
            MoveInDirection(Vector2.right);
        }
        else
        {
            MoveInDirection(Vector2.left);
        }

        if (CheckForPlayer())
        {
            SetState(GunnerChase.Create(target));
        }

        if (HitWall() || HitHole() || TimeToChange())
        {
            SetState(GunnerIdle.Create(target));
        }
    }

    private bool TimeToChange()
    {
        if (!target.facingRight && Math.Abs(transform.position.x - _patrolLeftPoint.x) <= 0.05f) return true;
        if (target.facingRight && Math.Abs(transform.position.x - _patrolRightPoint.x) <= 0.05f) return true;
        return false;
    }
}
