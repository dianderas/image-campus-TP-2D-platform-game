using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : MovementState
{
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.fall);
    }

    protected override void HandleJumpPressed()
    {
        // Dont allow jumping in fall state
    }

    protected override void HandleDash()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Dash));
    }

    public override void StateUpdate()
    {
        movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y += agent.agentData.gravityModified * Physics2D.gravity.y * Time.deltaTime;
        agent.rb2d.velocity = movementData.currentVelocity;

        CalculateVelocity();
        SetPlayerVelocity();

        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
        else if (agent.CompareTag("Player") && agent.wallDetector.isTouchingWall &&
            Mathf.Abs(agent.agentInput.MovementVector.x) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Slide));
        }
    }
}