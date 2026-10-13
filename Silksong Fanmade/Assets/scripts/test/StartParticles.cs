using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticles : MonoBehaviour
{

    public Transform emptyObject;
    [SerializeField] ParticleSystem impacto = null;
    void Start()
    {
       impacto.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        impacto.transform.position =  emptyObject.position;
    }
}
