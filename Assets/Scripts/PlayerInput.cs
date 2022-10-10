using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    public CharacterSelectedSO characterSelected;

    [field: SerializeField]
    public Vector2 MovementVector { get; private set; }

    public event Action OnAttack, OnjumpPressed, OnJumpReleased, OnDash, OnWeaponChange, OnSwapAgent;
    public event Action OnBlockAttackPressed, OnBlockAttackReleased;

    public event Action<Vector2> OnMovement;

    public KeyCode jumpKey, attackKey, menuKey, dashkey, swapAgent, blockAttack;

    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            GetDashInput();
            GetSwapAgentInput();
            GetBlockAttackInput();
        }

        GetMenuInput();
    }

    private void GetBlockAttackInput()
    {
        if (characterSelected.characterType == CharacterType.Drums)
        {
            if (Input.GetKeyDown(blockAttack))
            {
                OnBlockAttackPressed?.Invoke();
            }
            if (Input.GetKeyUp(blockAttack))
            {
                OnBlockAttackReleased?.Invoke();
            }
        }
    }

    private void GetSwapAgentInput()
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
        if (characterSelected.characterType == CharacterType.Drums)
        {
            if (Input.GetKeyDown(attackKey))
            {
                OnAttack?.Invoke();
            }
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
