using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : MovementState
{
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.dash);
        StartCoroutine(Dash());
    }

    public override void StateUpdate()
    {
        // prevent
    }

    private IEnumerator Dash()
    {
        float originalGravity = agent.rb2d.gravityScale;
        agent.rb2d.gravityScale = 0f;
        agent.rb2d.velocity = new Vector2(agent.transform.localScale.x * agent.agentData.dashForce, 0f);
        yield return new WaitForSeconds(agent.agentData.dashTime);
        agent.rb2d.gravityScale = originalGravity;
        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
        else if (agent.rb2d.velocity.y <= 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
        }

    }
}