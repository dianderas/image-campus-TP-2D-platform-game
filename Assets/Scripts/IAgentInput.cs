using System;
using UnityEngine;

public interface IAgentInput
{
    Vector2 MovementVector { get; }

    event Action OnAttack;
    event Action OnjumpPressed;
    event Action OnJumpReleased;
    event Action OnDash;
    event Action OnWeaponChange;
    event Action OnSwapAgent;
    event Action<Vector2> OnMovement;
}