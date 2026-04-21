using UnityEngine;

public class ChaseState : State
{
    private Transform target;
    protected override string AnimBoolName => "isRunning";

    public ChaseState(Enemy enemy) : base(enemy) { }

    public override void FixedUpdate()
    {
        //1. Check for a target
        target = senses.GetChaseTarget();

        if(!target)
        {
            stateMachine.ChangeState(new PatrolState(enemy));
            return;
        }

        enemy.FaceTarget(target);


        //2. Check if can attack
        if (senses.IsInMeleeRange(target) && combat.CanMeleeAttack())
        {
            stateMachine.ChangeState(new MeleeAttackState(enemy));
            return;
        }


        //3. Chck if have reached target
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);
        if(distance <= config.turnThreshold)
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //4. Check for obstacles
        if(senses.IsHittingWall() || senses.IsAtCliff())
        {
            stateMachine.ChangeState(new IdleState(enemy));
            rb.linearVelocity = Vector2.zero;
            return;
        }

        //5. Move toward target
        rb.linearVelocity = new Vector2(config.chaseSpeed * enemy.FacingDirection, rb.linearVelocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        rb.linearVelocity = Vector2.zero;
    }
}
