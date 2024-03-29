using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnSystem
{
    public class RespawnPointManager : MonoBehaviour
    {
        List<RespawnPoint> respawnPoints = new List<RespawnPoint>();
        RespawnPoint currentRespawnPoint;

        private void Awake()
        {
            foreach (Transform item in transform)
            {
                respawnPoints.Add(item.GetComponent<RespawnPoint>());
            }
            currentRespawnPoint = respawnPoints[0];
        }

        public void UpdateRespawnPoint(RespawnPoint newRespawnPoint)
        {
            currentRespawnPoint.DisableRespwanPoint();
            currentRespawnPoint = newRespawnPoint;
        }

        public void Respawn(GameObject objectToRespawn)
        {
            //currentRespawnPoint.SetPlayerGO(objectToRespawn);
            currentRespawnPoint.RespawnPlayer();
            objectToRespawn.SetActive(true);
        }

        public void RespawnAt(RespawnPoint spawnPoint, GameObject playerGO)
        {
            spawnPoint.SetPlayerGO(playerGO);
            Respawn(playerGO);
        }

        public void ResetAllSpawnPoint()
        {
            foreach (var item in respawnPoints)
            {
                item.ResetRespawnPoint();
            }
            currentRespawnPoint = respawnPoints[0];
        }
    }
}
