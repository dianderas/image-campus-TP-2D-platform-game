using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class SwapAgentManager : MonoBehaviour
{
    private AgentStorage agentStorage;
    [SerializeField]
    private GameObject hihat;
    [SerializeField]
    private GameObject drums;

    public UnityEvent OnAgentSwap;

    private void Awake()
    {
        agentStorage = new AgentStorage();
        agentStorage.AddAgent(drums);
        agentStorage.AddAgent(hihat);
    }

    private void Start()
    {
        agentStorage.Initialize();
    }

    public void SwapAgent()
    {
        Debug.Log("SwapAgent in Manager");
        agentStorage.SwapAgent();
        OnAgentSwap?.Invoke();
    }
}
