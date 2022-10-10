using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAttackState : State
{
    private bool blockAttackPressed = false;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.block);
        agent.damagable.isDamagable = false;
        agent.rb2d.velocity = Vector2.zero;
        agent.stopFaceDirectionListener();

        blockAttackPressed = true;
    }

    protected override void HandleBlockAttackReleased()
    {
        blockAttackPressed = false;
    }

    public override void StateUpdate()
    {
        ControlBlocking();
    }

    private void ControlBlocking()
    {
        if (!blockAttackPressed)
        {
            agent.startFaceDirectionListener();
            agent.damagable.isDamagable = true;
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
    }

    protected override void HandleSwapAgent()
    {
        // prevent swap
    }

    protected override void ExitState()
    {
        agent.damagable.isDamagable = true;
        agent.startFaceDirectionListener();
    }
}


