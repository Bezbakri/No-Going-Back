using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    [SerializeField] private int MAX_HEALTH = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        this.health -= amount;

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