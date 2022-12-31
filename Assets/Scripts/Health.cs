using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    [SerializeField] private int MAX_HEALTH = 100;

    

    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return MAX_HEALTH;
    }

    public void SetHealth(int maxHealth, int setHealth)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = setHealth;
    }

    public IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if (this.GetComponent<HealthBar>() != null)
        {
            HealthBar healthBar = this.GetComponent<HealthBar>();
            healthBar.UpdateHealthBar();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        StartCoroutine(VisualIndicator(Color.green));

        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        } else
        {
            this.health += amount;
        }
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}