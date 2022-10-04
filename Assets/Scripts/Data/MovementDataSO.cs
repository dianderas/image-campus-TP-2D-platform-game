using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementDataSO", menuName = "Agent/MovementData")]
public class MovementDataSO : ScriptableObject
{
    public float horizontalMovementDirection;
    public float currentSpeed;
    public Vector2 currentVelocity;
    public bool canAirJump = false;
    public bool airJumped = false;
}
