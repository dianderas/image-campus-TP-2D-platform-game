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
        if (agent.characterSharedData.canAirJump)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Jump));
            agent.characterSharedData.canAirJump = false;
        }
    }

    protected override void HandleDash()
    {
        // prevent dash
    }

    public override void StateUpdate()
    {
        agent.characterSharedData.currentVelocity = agent.rb2d.velocity;
        agent.characterSharedData.currentVelocity.y += agent.agentData.gravityModified * Physics2D.gravity.y * Time.deltaTime;
        agent.rb2d.velocity = agent.characterSharedData.currentVelocity;

        CalculateVelocity();
        SetPlayerVelocity();

        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
        else if (agent.CompareTag("Player") && agent.wallDetector.isTouchingWall &&
            Mathf.Abs(agent.agentInput.MovementVector.x) > 0 &&
            agent.characterSelected.characterType == CharacterType.Hithat)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Slide));
        }
    }
}
