using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : MovementState
{
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.slide);
    }

    protected override void HandleJumpPressed()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.WallJump));
    }

    public override void StateUpdate()
    {
        agent.characterSharedData.currentVelocity = agent.rb2d.velocity;
        agent.characterSharedData.currentVelocity.y = -agent.agentData.wallSlideSpeed;
        agent.rb2d.velocity = agent.characterSharedData.currentVelocity;

        if (Mathf.Abs(agent.agentInput.MovementVector.x) == 0 || !agent.wallDetector.isTouchingWall)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
        }
    }
}
