using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2: MonoBehaviour
{
    public Transform topdosEmptyObject;
    public float dosForwardOffset = 1.0f; // Distance in front of the object
    public float dosRayLength = 5.0f;     // How far down the ray goes
    public LayerMask dosTargetLayer; // Filter which layers to hits

    [SerializeField] Hitpoints dhp;
    Triggger particula;
     [SerializeField] ParticleSystem dimpacto = null;
     public void Raywizard()
    {
        // 1. Define the origin and direction
        Vector3 origin = topdosEmptyObject.position + (transform.forward * dosForwardOffset);
        Vector3 direction = transform.TransformDirection(Vector3.down);

        // 2. Variable to hold impact details
        RaycastHit hit;
        if (TryGetComponent<Collider>(out Collider col))
        {
            origin.y += col.bounds.extents.y;
        }
        // 3. Fire the raycast
        if (Physics.Raycast(origin, direction, out hit, dosRayLength, dosTargetLayer))
        {
            
            dhp.ChangeHealth(-2);
            dimpacto.transform.position = hit.point;
            

            // 4. Play the particle system
            if (!dimpacto.isPlaying)
            {
                dimpacto.Play();
            }
            
        }
    }
}