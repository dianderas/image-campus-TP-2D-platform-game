using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class GiveAgentAWeapon : MonoBehaviour
    {
        public List<WeaponData> weaponData = new List<WeaponData>();

        private void Start()
        {
            Agent agent = GetComponent<Agent>();
            if (agent == null)
            {
                return;
            }
            foreach (var item in weaponData)
            {
                agent.agentWeapon.AddWeaponData(item);
            }
        }
    }
}

