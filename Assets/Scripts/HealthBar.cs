using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private float health;
    private float MAX_HEALTH;


    public void UpdateHealthBar()
    {
        health = (float) this.GetComponent<Health>().getHealth();
        MAX_HEALTH = (float) this.GetComponent<Health>().getMaxHealth();
        textMeshPro.text = health.ToString() + "/" + MAX_HEALTH.ToString();
        healthBar.fillAmount = Mathf.Clamp(health / MAX_HEALTH, 0, 1f);
    }
}
