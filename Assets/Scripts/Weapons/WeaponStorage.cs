using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponStorage
    {
        private List<WeaponData> weaponDataList = new List<WeaponData>();
        private int currentWeapontIndex = -1;

        public int WeaponCount { get => weaponDataList.Count; }

        internal WeaponData GetCurrentWeapon()
        {
            if (currentWeapontIndex == -1)
            {
                return null;
            }

            return weaponDataList[currentWeapontIndex];
        }

        internal WeaponData SwapWeapon()
        {
            if (currentWeapontIndex == -1)
            {
                return null;
            }

            currentWeapontIndex++;

            if (currentWeapontIndex >= weaponDataList.Count)
            {
                currentWeapontIndex = 0;
            }

            return weaponDataList[currentWeapontIndex];
        }

        internal bool AddWeaponData(WeaponData weaponData)
        {
            if (weaponDataList.Contains(weaponData))
            {
                return false;
            }

            weaponDataList.Add(weaponData);
            currentWeapontIndex = weaponDataList.Count - 1;
            return true;
        }

        internal List<string> GetPlayerWeaponNames()
        {
            return weaponDataList.Select(weapon => weapon.name).ToList();
        }
    }

}
