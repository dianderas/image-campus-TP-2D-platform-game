using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : State
{
    public RuntimeAnimatorController[] controllers;

    protected override void EnterState()
    {
        if (agent.agentData.characterType == CharacterType.Hithat)
        {
            agent.agentData.characterType = CharacterType.Drums;
            agent.animationManager.animator.runtimeAnimatorController = controllers[1];
        }
        else
        {
            agent.agentData.characterType = CharacterType.Hithat;
            agent.animationManager.animator.runtimeAnimatorController = controllers[0];
        }
    }

    protected override void HandleMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Move));
        }
    }
}
