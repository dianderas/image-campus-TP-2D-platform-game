using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public UnityEvent OnEnter, OnExit;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnAttack += HandleAttack;
        this.agent.agentInput.OnjumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased += HandleJumpReleased;
        this.agent.agentInput.OnMovement += HandleMovement;
        this.agent.agentInput.OnDash += HandleDash;
        OnEnter?.Invoke();
        EnterState();
    }

    protected virtual void EnterState() { }

    protected virtual void HandleMovement(Vector2 obj) { }

    protected virtual void HandleDash() { }

    protected virtual void HandleJumpReleased() { }

    protected virtual void HandleJumpPressed()
    {
        TestJumpTransition();
    }

    private void TestJumpTransition()
    {
        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Jump));
        }
    }

    protected virtual void HandleAttack()
    {
        TestAttackTransition();
    }


    public virtual void StateUpdate()
    {
        TestFallTransition();
    }

    protected bool TestFallTransition()
    {
        if (!agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
            return true;
        }
        return false;
    }

    public virtual void GetHit()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.GetHit));
    }

    public virtual void StateFixedUpdate() { }

    public virtual void Die()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Die));
    }

    public void Exit()
    {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnjumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnMovement -= HandleMovement;
        this.agent.agentInput.OnDash -= HandleDash;
        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState() { }

    protected virtual void TestAttackTransition()
    {
        if (agent.agentWeapon.CanIUseWeapon(agent.groundDetector.isGrounded))
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Attack));
        }
    }
}
