using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.AI
{
    public class AIBehaviourMeleeAttack : AIBehaviour
    {
        public AIMeleeAttackDetector meleeRangeDetector;

        [SerializeField]
        private bool isWaiting;

        [SerializeField]
        private float delay = 2;

        private void Awake()
        {
            if (meleeRangeDetector == null)
            {
                meleeRangeDetector = transform.parent.GetComponentInParent<AIMeleeAttackDetector>();
            }
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isWaiting || !meleeRangeDetector.PlayerDetected)
            {
                return;
            }
            enemyAI.CallAttack();
            isWaiting = true;
            StartCoroutine(AttackDelayCoroutine());
        }

        IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }
    }
}

