using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : MovementState
{
    public RuntimeAnimatorController[] controllers;
    public CharacterSelectedSO characterSelected;
    public AgentDataSO[] agentDatas;

    protected override void EnterState()
    {
        if (!agent.groundDetector.isGrounded && !agent.characterSharedData.airJumped)
        {
            agent.characterSharedData.canAirJump = true;
            agent.characterSharedData.airJumped = true;
        }

        // TODO: maybe need better approach
        if (characterSelected.characterType == CharacterType.Hithat)
        {
            agent.agentData = agentDatas[1];
            characterSelected.characterType = CharacterType.Drums;
            agent.animationManager.animator.runtimeAnimatorController = controllers[1];
            agent.wallDetector.enabled = false;
        }
        else
        {
            agent.agentData = agentDatas[0];
            characterSelected.characterType = CharacterType.Hithat;
            agent.animationManager.animator.runtimeAnimatorController = controllers[0];
        }

        agent.damagable.CurrentHealth = agent.agentData.currentHealth;
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Move));
    }
}
