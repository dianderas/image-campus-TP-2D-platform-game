using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.AI
{
    public class AIShootBehaviour : AIBehaviour
    {
        public AIPlayerDetector playerDetector;

        [SerializeField]
        private bool isWaiting;
        [SerializeField]
        private float delay = 1;

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isWaiting)
            {
                return;
            }
            if (playerDetector.PlayerDetected)
            {
                isWaiting = true;
                enemyAI.CallOnMovement(playerDetector.DirectionToTarget);
                enemyAI.CallAttack();
                StartCoroutine(AttackDelayCoroutine());
            }
        }

        IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }
    }
}
