using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public AgentDataSO agentData;

    private void Start() {
        SetMaxHealth(agentData.health);
    }

    private void Update() {
        SetHealth(agentData.currentHealth);
    }
    
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}