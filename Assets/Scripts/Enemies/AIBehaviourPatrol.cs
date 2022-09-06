using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.AI
{
    public class AIBehaviourPatrol : AIBehaviour
    {

        public AIEndPlatformDetector changeDirectionDectector;
        private Vector2 movementVector = Vector2.zero;

        private void Awake()
        {
            if (changeDirectionDectector == null)
            {
                changeDirectionDectector = GetComponent<AIEndPlatformDetector>();
            }
        }

        private void Start()
        {
            changeDirectionDectector.OnPathBlocked += HandlePathBlocked;
            movementVector = new Vector2(Random.value > 0.5f ? 1 : -1, 0);
        }

        private void HandlePathBlocked()
        {
            movementVector *= new Vector2(-1, 0);
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = movementVector;
            enemyAI.CallOnMovement(movementVector);
        }
    }
}
