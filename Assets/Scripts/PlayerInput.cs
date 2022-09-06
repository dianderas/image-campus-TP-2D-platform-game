using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    public CharacterSelectedSO characterSelected;

    [field: SerializeField]
    public Vector2 MovementVector { get; private set; }

    public event Action OnAttack, OnjumpPressed, OnJumpReleased, OnDash, OnWeaponChange, OnSwapAgent;

    public event Action<Vector2> OnMovement;

    public KeyCode jumpKey, attackKey, menuKey, dashkey, swapAgent;

    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            GetDashInput();
            GetSwapAgent();
        }

        GetMenuInput();
    }

    private void GetSwapAgent()
    {
        if (Input.GetKeyDown(swapAgent))
        {
            OnSwapAgent?.Invoke();
        }
    }

    private void GetDashInput()
    {
        if (Input.GetKeyDown(dashkey))
        {
            if (characterSelected.characterType == CharacterType.Hithat)
            {
                OnDash?.Invoke();
            }
        }
    }


    private void GetMenuInput()
    {
        if (Input.GetKeyDown(menuKey))
        {
            OnMenuKeyPressed?.Invoke();
        }
    }

    private void GetAttackInput()
    {
        if (Input.GetKeyDown(attackKey))
        {
            OnAttack?.Invoke();
        }
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            OnjumpPressed?.Invoke();
        }
        if (Input.GetKeyUp(jumpKey))
        {
            OnJumpReleased?.Invoke();
        }
    }

    private void GetMovementInput()
    {
        MovementVector = GetMovementVector();
        OnMovement?.Invoke(MovementVector);
    }

    private Vector2 GetMovementVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
