using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory : MonoBehaviour
{
    [SerializeField]
    private State Idle, Move, Fall, Jump, Attack, GetHit, Die, Slide, Dash, WallJump;

    public State GetState(StateType stateType)
        => stateType switch
        {
            StateType.Idle => Idle,
            StateType.Move => Move,
            StateType.Fall => Fall,
            StateType.Jump => Jump,
            StateType.Attack => Attack,
            StateType.GetHit => GetHit,
            StateType.Slide => Slide,
            StateType.Dash => Dash,
            StateType.Die => Die,
            StateType.WallJump => WallJump,
            _ => throw new System.Exception("State not defined " + stateType.ToString())
        };

    internal void Initialize(Agent agent)
    {
        State[] states = GetComponents<State>();
        foreach (var state in states)
        {
            state.InitializeState(agent);
        }
    }
}

public enum StateType
{
    Idle,
    Move,
    Fall,
    Jump,
    Attack,
    GetHit,
    Die,
    Slide,
    Dash,
    WallJump,
}