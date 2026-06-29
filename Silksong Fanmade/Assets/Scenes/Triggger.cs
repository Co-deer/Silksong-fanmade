using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggger : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Collect();

        }
    }

    public void Collect()
    {

        collectParticle.Play();

    }
}
