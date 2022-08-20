using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AgentStorage
{
    private List<GameObject> agentDataList = new List<GameObject>();
    private int currentAgentIndex = 0;

    public int AgentCount { get => agentDataList.Count; }

    internal void Initialize()
    {
        agentDataList[currentAgentIndex].SetActive(true);
    }

    internal GameObject GetCurrentAgent()
    {
        if (currentAgentIndex == -1)
        {
            return null;
        }

        return agentDataList[currentAgentIndex];
    }

    internal void SwapAgent()
    {
        Debug.Log("SwapAgent in Storage");
        agentDataList[currentAgentIndex].SetActive(false);

        currentAgentIndex++;

        if (currentAgentIndex >= agentDataList.Count)
        {
            currentAgentIndex = 0;
        }

        agentDataList[currentAgentIndex].SetActive(true);
    }

    internal bool AddAgent(GameObject agent)
    {
        if (agentDataList.Contains(agent))
        {
            return false;
        }

        agentDataList.Add(agent);
        currentAgentIndex = agentDataList.Count - 1;
        return true;
    }
}
