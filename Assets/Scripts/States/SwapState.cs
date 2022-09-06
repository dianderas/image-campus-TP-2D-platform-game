using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : State
{
    public RuntimeAnimatorController[] controllers;
    public CharacterSelectedSO characterSelected;
    public AgentDataSO[] agentDatas;

    protected override void EnterState()
    {
        // TODO: maybe need better approach
        if (characterSelected.characterType == CharacterType.Hithat)
        {
            agent.agentData = agentDatas[1];
            characterSelected.characterType = CharacterType.Drums;
            agent.animationManager.animator.runtimeAnimatorController = controllers[1];
        }
        else
        {
            agent.agentData = agentDatas[0];
            characterSelected.characterType = CharacterType.Hithat;
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
