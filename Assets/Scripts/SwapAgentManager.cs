using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class SwapAgentManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hihat;
    [SerializeField]
    private GameObject drums;
    private bool isHihat = true;

    public UnityEvent OnAgentSwap;

    private void Start()
    {
        drums.SetActive(false);
    }

    public void SwapAgent()
    {
        hihat.SetActive(!hihat.activeSelf);
        drums.SetActive(!drums.activeSelf);
    }
}
