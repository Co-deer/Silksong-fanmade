using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemies : MonoBehaviour
{
    public float maxHealth;
    
    public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);
    public event HealthChangedHandler OnHealthChanged;
    private void Start()
    {
        
    }
    [SerializeField] float currentHealth;
    public float CurrentHealth => currentHealth;

     
    public void ChangeHealth(float amount) {
    float oldHealth = currentHealth;
    currentHealth += amount;
    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);


    OnHealthChanged?.Invoke(this, oldHealth, currentHealth);
    if (currentHealth <= 0)
    {
      Destroy(this.gameObject);
    }
    
    }

}

