using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCharacterData", menuName = "Data/Character Data/Base Data")]
public class CharacterData : ScriptableObject
{
        [Header("Move State")]
        public float movementVelocity = 10f;

        [Header("Jump State")]
        public float jumpVelocity = 15f;
        public int amountOfJumps = 1;

        [Header("Wall Jump State")]
        public float wallJumpVelocity = 20f;
        public float wallJumpTime = 0.4f;
        public Vector2 wallJumpAngle = new Vector2(1, 2);

        [Header("In Air State")]
        public float coyoteTime = 0.2f;
        public float variableJumpHeightMultiplier = 0.5f;

        [Header("Wall Slide State")]
        public float wallSlideVelocity = 3f;

        [Header("Check Variables")]
        public float groundCheckRadius = 2f;
        public float wallCheckDistance = 2f;
        public LayerMask whatIsGround;
}