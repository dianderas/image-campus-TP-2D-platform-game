using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : MovementState
{
    protected Vector2 movementDirection;

    protected new void CalculateSpeed(Vector2 movementVector, MovementDataSO characterSharedData)
    {
        movementDirection = movementVector.normalized;

        if (movementVector.magnitude > 0)
        {
            characterSharedData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
        }
        else
        {
            characterSharedData.currentSpeed -= agent.agentData.deacceleration * Time.deltaTime;
        }

        characterSharedData.currentSpeed = Mathf.Clamp(characterSharedData.currentSpeed, 0, agent.agentData.maxSpeed);
    }

    protected new void CalculateVelocity()
    {
        CalculateSpeed(agent.agentInput.MovementVector, agent.characterSharedData);
        CalculateHorizontalDirection(agent.characterSharedData);
        agent.characterSharedData.currentVelocity = movementDirection * agent.characterSharedData.currentSpeed;
    }

    public override void StateUpdate()
    {
        CalculateVelocity();
        SetPlayerVelocity();

        // if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
        // {
        //     agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        // }
    }
}
