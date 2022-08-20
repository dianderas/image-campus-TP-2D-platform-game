using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.AI
{
    public abstract class AIEnemy : MonoBehaviour, IAgentInput
    {
        public Vector2 MovementVector { get; set; }
        public event Action OnAttack;
        public event Action OnjumpPressed;
        public event Action OnJumpReleased;
        public event Action OnDash;
        public event Action OnWeaponChange;
        public event Action OnSwapAgent;
        public event Action<Vector2> OnMovement;

        public void CallOnAttack()
        {
            OnAttack?.Invoke();
        }

        public void CallOnJumpPressed()
        {
            OnjumpPressed?.Invoke();
        }

        public void CallOnJumpReleased()
        {
            OnJumpReleased?.Invoke();
        }

        public void CallOnMovement(Vector2 input)
        {
            OnMovement?.Invoke(input);
        }

        public void CallAttack()
        {
            OnAttack?.Invoke();
        }

        public void CallOnDash()
        {
            OnDash?.Invoke();
        }

        public void CallOnWeapongChange()
        {
            OnWeaponChange?.Invoke();
        }
    }
}


