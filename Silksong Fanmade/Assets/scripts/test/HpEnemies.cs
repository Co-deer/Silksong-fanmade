using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemies : MonoBehaviour
{
    public float maxHealth;
    
    
    [SerializeField]
    float currentHealth;
    public float CurrentHealth => currentHealth;
    public void ChangeHealth(float amount) {
    float oldHealth = currentHealth;
    currentHealth += amount;
    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    if (currentHealth <= 0)
    {
      Destroy(this.gameObject);
    }
    
    }

}

