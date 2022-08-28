using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GD.AI
{
    public class AIMeleeAttackDetector : MonoBehaviour
    {
        public bool PlayerDetected { get; private set; }

        public LayerMask targetLayer;

        public UnityEvent<GameObject> OnPlayerDetected;

        [Header("Gizmo parameters")]
        [Range(0.1f, 1)]
        public float radius;

        public Color gizmoColor = Color.green;
        public bool showGizmos = true;

        private void Update()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
            PlayerDetected = collider != null;
            if (PlayerDetected)
            {
                OnPlayerDetected?.Invoke(collider.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawSphere(transform.position, radius);
            }
        }
    }
}

