using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanAttack : MonoBehaviour
{
    
    [SerializeField] Collider m_Collider;
    [SerializeField] HpEnemies hppp;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
       
    }


    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            m_Collider.enabled = !m_Collider.enabled;
        }

        

    }

    private void OnTriggerEnter(Collider Enemy)
    {
        hppp.ChangeHealth(-5);
    }
}
