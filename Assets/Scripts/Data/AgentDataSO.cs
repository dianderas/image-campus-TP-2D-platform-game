using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/Data")]
public class AgentDataSO : ScriptableObject
{
    [Header("Movement data")]
    [Space]
    public int health = 2;
    [Header("Movement data")]
    [Space]
    public float maxSpeed = 6;
    public float acceleration = 50;
    public float deacceleration = 50;

    [Header("Jump data")]
    [Space]
    public float jumpForce = 12;
    public float lowJumpMultiplier = 2;
    public float gravityModified = 0.5f;

    [Header("Climb data")]
    [Space]
    public float climbHorizontalSpeed = 2;
    public float climbVerticalSpeed = 5;

    [Header("Slide data")]
    [Space]
    public float wallSlideSpeed = 1;

    [Header("Wall data")]
    [Space]
    public float wallJumpForce = 18;
    public Vector2 wallJumpAngle;

    [Header("Dash data")]
    [Space]
    public float dashForce = 20;
    public float dashTime = 0.2f;
}
