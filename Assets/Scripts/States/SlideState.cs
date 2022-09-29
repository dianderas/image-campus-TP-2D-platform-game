using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : MovementState
{
    public float delayAfterReleaseSlide = 0.2f;

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
        agent.stopFaceDirectionListener();
        agent.characterSharedData.currentVelocity = agent.rb2d.velocity;
        agent.characterSharedData.currentVelocity.y = -agent.agentData.wallSlideSpeed;
        agent.rb2d.velocity = agent.characterSharedData.currentVelocity;

        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }

        if (Mathf.Abs(agent.agentInput.MovementVector.x) == 0 || !agent.wallDetector.isTouchingWall)
        {
            //StartCoroutine(GoToFallState());
            GoToAnotherState();
        }
    }

    protected override void ExitState()
    {
        agent.startFaceDirectionListener();
    }

    private void GoToAnotherState()
    {
        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
        else
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
        }
    }

    IEnumerator GoToFallState()
    {
        yield return new WaitForSeconds(delayAfterReleaseSlide);
        GoToAnotherState();
    }
}
