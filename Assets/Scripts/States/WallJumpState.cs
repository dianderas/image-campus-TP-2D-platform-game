using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : MovementState
{
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.wallJump);

        var force = new Vector2(agent.agentData.wallJumpForce * -agent.transform.localScale.x * agent.agentData.wallJumpAngle.x,
            agent.agentData.wallJumpForce * agent.agentData.wallJumpAngle.y);
        agent.rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    protected override void HandleDash()
    {
        // prevent dash
    }

    public override void StateUpdate()
    {
        if (agent.rb2d.velocity.y <= 0 || agent.transform.localScale.x * agent.characterSharedData.horizontalMovementDirection < 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
        }
    }
}
