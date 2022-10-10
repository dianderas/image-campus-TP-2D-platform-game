using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovementState
{
    private bool jumpPressed = false;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.jump);
        agent.characterSharedData.currentVelocity = agent.rb2d.velocity;
        agent.characterSharedData.currentVelocity.y = agent.agentData.jumpForce;
        agent.rb2d.velocity = agent.characterSharedData.currentVelocity;
        jumpPressed = true;
    }

    protected override void HandleJumpPressed()
    {
        jumpPressed = true;

        if (agent.characterSharedData.canAirJump)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Jump));
            agent.characterSharedData.canAirJump = false;
        }
    }

    protected override void HandleJumpReleased()
    {
        jumpPressed = false;
    }

    protected override void HandleDash()
    {
        // prevent dash
    }

    public override void StateUpdate()
    {
        ControlJumpHeight();
        CalculateVelocity();
        SetPlayerVelocity();

        if (agent.rb2d.velocity.y <= 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
        }
    }

    private void ControlJumpHeight()
    {
        if (!jumpPressed)
        {
            agent.characterSharedData.currentVelocity = agent.rb2d.velocity;
            agent.characterSharedData.currentVelocity.y += agent.agentData.lowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
            agent.rb2d.velocity = agent.characterSharedData.currentVelocity;
        }
    }
}
