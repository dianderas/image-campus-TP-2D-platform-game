using System.Collections;
using System.Collections.Generic;
using RespawnSystem;
using UnityEngine;

public class DestroyFallingObjects : MonoBehaviour
{
    public LayerMask objectsToDestroyLayerMask;
    public Vector2 size;

    [Header("Gizmo parameters")]
    public Color gizmoColor = Color.red;
    public bool showGizmo = true;

    private void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, size, 0, objectsToDestroyLayerMask);
        if (collider != null)
        {
            Agent agent = collider.GetComponent<Agent>();
            if (agent == null)
            {
                Destroy(collider.gameObject);
                return;
            }
            var damagable = agent.GetComponent<Damagable>();
            if (damagable != null)
            {
                if (agent.CompareTag("Player"))
                {
                    agent.GetComponent<RespawnHelper>().RespawnPlayer();
                }
                /*
                damagable.GetHit(1);
                if (damagable.CurrentHealth == 0 && agent.CompareTag("Player"))
                {
                    agent.GetComponent<RespawmHelper>().RespawnPlayer();
                }
                */
            }
            // agent.AgentDied();
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmo)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(transform.position, size);
        }
    }
}
