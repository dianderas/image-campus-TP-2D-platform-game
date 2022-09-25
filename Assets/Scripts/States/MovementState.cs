using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementState : State
{
    public UnityEvent OnStep;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.run);
        agent.animationManager.OnAnimationAction.AddListener(() => OnStep.Invoke());

        agent.characterSharedData.horizontalMovementDirection = 0;
        agent.characterSharedData.currentSpeed = 0;
        agent.characterSharedData.currentVelocity = Vector2.zero;
    }

    protected override void HandleDash()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Dash));
    }

    public override void StateUpdate()
    {
        if (TestFallTransition())
        {
            return;
        }
        CalculateVelocity();
        SetPlayerVelocity();

        if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
    }

    protected void SetPlayerVelocity()
    {
        agent.rb2d.velocity = agent.characterSharedData.currentVelocity;
    }

    protected void CalculateVelocity()
    {
        CalculateSpeed(agent.agentInput.MovementVector, agent.characterSharedData);
        CalculateHorizontalDirection(agent.characterSharedData);
        agent.characterSharedData.currentVelocity = Vector3.right * agent.characterSharedData.horizontalMovementDirection *
            agent.characterSharedData.currentSpeed;
        agent.characterSharedData.currentVelocity.y = agent.rb2d.velocity.y;
    }

    protected void CalculateHorizontalDirection(MovementDataSO characterSharedData)
    {
        if (agent.agentInput.MovementVector.x > 0)
        {
            characterSharedData.horizontalMovementDirection = 1;
        }
        else if (agent.agentInput.MovementVector.x < 0)
        {
            characterSharedData.horizontalMovementDirection = -1;
        }
    }

    protected void CalculateSpeed(Vector2 movementVector, MovementDataSO characterSharedData)
    {
        if (Mathf.Abs(movementVector.x) > 0)
        {
            characterSharedData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
        }
        else
        {
            characterSharedData.currentSpeed -= agent.agentData.deacceleration * Time.deltaTime;
        }

        characterSharedData.currentSpeed = Mathf.Clamp(characterSharedData.currentSpeed, 0, agent.agentData.maxSpeed);
    }

    protected override void ExitState()
    {
        agent.animationManager.ResetEvents();
    }
}
