using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "Melee weapon data", menuName = "Weapons/MeleeWeaponData")]
    public class MeleeWeaponData : WeaponData
    {
        public float attackRange = 2;

        public override bool CanBeUsed(bool isGrounded)
        {
            return isGrounded;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            // Debug.Log("Weapon used: " + weaponName);
            // TODO: Raycast esta en el botton
            RaycastHit2D hit = Physics2D.Raycast(agent.agentWeapon.transform.position, direction, attackRange,
                hittableMask);

            if (hit.collider != null)
            {
                foreach (var hittable in hit.collider.GetComponents<IHittable>())
                {
                    hittable.GetHit(agent.gameObject, weaponDamage);
                }
            }

        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
            Gizmos.DrawLine(origin, origin + direction * attackRange);
        }
    }
}
