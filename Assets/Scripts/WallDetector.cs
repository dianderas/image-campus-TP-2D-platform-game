using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public LayerMask groundMask;

    public bool isTouchingWall = false;

    [Header("Gizmo parameters:")]
    [Range(0, 2)]
    public float boxCastWidth = 1;
    [Range(0, 2)]
    public float boxCastHeight = 1;
    public Color gizmoColorNotGrounded = Color.red;
    public Color gizmoColorIsGrounded = Color.magenta;

    public void CheckIsTouchingWall()
    {
        isTouchingWall = Physics2D.OverlapBox(transform.position,
            new Vector2(boxCastWidth, boxCastHeight), 0, groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColorNotGrounded;
        if (isTouchingWall)
        {
            Gizmos.color = gizmoColorIsGrounded;
        }
        Gizmos.DrawWireCube(transform.position, new Vector3(boxCastWidth, boxCastHeight));
    }
}
