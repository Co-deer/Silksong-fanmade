using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletParticle : MonoBehaviour
{
    public ParticleSystem parSystem;

    public GameObject spark;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();


    private void Start()
    {
        
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        
            
            parSystem.Play();

        

    }

    private void OnParticleCollision(GameObject other)
    {
        
        int events = parSystem.GetCollisionEvents(other, colEvents);

        Debug.Log("Hit");

        if (other.TryGetComponent<HpEnemies>(out HpEnemies enemigo))
            {
                // Esto solo se ejecutará si el objeto realmente tiene el componente HpEnemies
                enemigo.ChangeHealth(-5);
            }

    }















}
