using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class Agent : MonoBehaviour
{
    public AgentDataSO agentData;
    public MovementDataSO movementData;
    public CharacterSelectedSO characterSelected;

    public Rigidbody2D rb2d;
    public IAgentInput agentInput;
    public AgentAnimation animationManager;
    public AgentRenderer agentRenderer;
    public GroundDetector groundDetector;
    public WallDetector wallDetector;

    public State currentState = null, previousState = null;

    [HideInInspector]
    public AgentWeaponManager agentWeapon;

    [SerializeField]
    public StateFactory stateFactory;
    private Damagable damagable;

    [Header("State debugging")]
    public string stateName = "";

    [field: SerializeField]
    private UnityEvent OnRespawnRequired { get; set; }
    [field: SerializeField]
    public UnityEvent OnAgentDie { get; set; }

    private void Awake()
    {
        agentInput = GetComponentInParent<IAgentInput>();
        rb2d = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        wallDetector = GetComponentInChildren<WallDetector>();
        agentWeapon = GetComponentInChildren<AgentWeaponManager>();
        stateFactory = GetComponentInChildren<StateFactory>();
        damagable = GetComponent<Damagable>();

        stateFactory.Initialize(this);
    }

    private void Start()
    {
        agentInput.OnMovement += agentRenderer.FaceDirection;
        InitializeAgent();
    }

    private void InitializeAgent()
    {
        TransitionToState(stateFactory.GetState(StateType.Idle));
        damagable.Initialize(agentData.health);
        // TODO: this compareTag need abstract interface.
        if (CompareTag("Player"))
        {
            characterSelected.characterType = CharacterType.Hithat;
        }
    }

    public void AgentDied()
    {
        if (damagable.CurrentHealth > 0)
        {
            OnRespawnRequired?.Invoke();
        }
        else
        {
            currentState.Die();
        }
    }

    public void GetHit()
    {
        currentState.GetHit();
    }

    internal void TransitionToState(State desiredState)
    {
        if (desiredState == null)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.Exit();
        }
        previousState = currentState;
        currentState = desiredState;
        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }

    private void Update()
    {
        currentState.StateUpdate();
    }

    private void FixedUpdate()
    {
        if (CompareTag("Player") && characterSelected.characterType == CharacterType.Hithat)
        {
            wallDetector?.CheckIsTouchingWall();
        }
        groundDetector.CheckIsGrounded();
        currentState.StateFixedUpdate();
    }
}
