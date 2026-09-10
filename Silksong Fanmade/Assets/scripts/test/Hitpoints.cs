using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{

    public float maxHealth;
    
    private void Start()
    {
        
    }
    // Define the health changed event and handler delegate.
public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);
public event HealthChangedHandler OnHealthChanged;

// Show in inspector
[SerializeField]
float currentHealth;
// Allow other scripts a readonly property to access current health
public float CurrentHealth => currentHealth;

public void ChangeHealth(float amount) {
   float oldHealth = currentHealth;
   currentHealth += amount;
   currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

   // Fire off health change event.
   OnHealthChanged?.Invoke(this, oldHealth, currentHealth);

   if (currentHealth <= 0)
    {
      Destroy(this.gameObject);
    }
}

}
