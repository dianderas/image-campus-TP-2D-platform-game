using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : MovementState
{
    private float originalGravity;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.dash);
        StartCoroutine(Dash());
    }

    // Note: unuse
    private void TransitionAnotherState()
    {
        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
        else if (agent.rb2d.velocity.y <= 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
        }
    }

    public override void StateUpdate()
    {
        // prevent
    }

    protected override void HandleDash()
    {
        // prevent
    }

    protected override void ExitState()
    {
        agent.rb2d.gravityScale = originalGravity;
    }

    private IEnumerator Dash()
    {
        originalGravity = agent.rb2d.gravityScale;
        agent.rb2d.gravityScale = 0;
        agent.rb2d.velocity = new Vector2(agent.transform.localScale.x * agent.agentData.dashForce, 0f);
        yield return new WaitForSeconds(agent.agentData.dashTime);
        agent.rb2d.gravityScale = originalGravity;
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
        //TransitionAnotherState();
    }
}
