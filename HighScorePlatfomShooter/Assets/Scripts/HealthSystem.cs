using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public bool isInvincible = false;
    public UnityEvent onDie;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isInvincible) { return; }

        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        currentHealth += amount;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void Die()
    {
        onDie.Invoke();
    }
}
