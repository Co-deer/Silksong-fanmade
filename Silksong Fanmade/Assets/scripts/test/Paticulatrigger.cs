using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paticulatrigger : MonoBehaviour
{

    public ParticleSystem particulaSecundaria;
    // Start is called before the first frame update
    void OnParticleTrigger()
    {
        
        System.Collections.Generic.List<ParticleSystem.Particle> enterParticles = new System.Collections.Generic.List<ParticleSystem.Particle>();
        
        int numEnter = GetComponent<ParticleSystem>().GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterParticles);

        if (particulaSecundaria != null && !particulaSecundaria.isPlaying)
            {
                particulaSecundaria.Play();
            }

    
    }
}