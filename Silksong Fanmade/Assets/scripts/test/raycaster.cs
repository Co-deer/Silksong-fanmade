using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycaster : MonoBehaviour
{
    public float maxDistance = 50f;
    public LayerMask targetLayer; // Filter which layers to hit
    public Vector3 lastHit;
     [SerializeField] Triggger particula;
     [SerializeField] ParticleSystem impacto = null;
     public void Raywizard()
    {
        // 1. Define the origin and direction
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // 2. Variable to hold impact details
        RaycastHit hit;

        // 3. Fire the raycast
        if (Physics.Raycast(origin, direction, out hit, maxDistance, targetLayer))
        {
            
              impacto.transform.position = hit.point;
            impacto.transform.rotation = Quaternion.LookRotation(hit.normal);

            // 4. Play the particle system
            if (!impacto.isPlaying)
            {
                impacto.Play();
            }
            
        }
    }
}