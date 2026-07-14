using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycaster : MonoBehaviour
{
    public Transform topEmptyObject;
    public float forwardOffset = 1.0f; // Distance in front of the object
    public float rayLength = 5.0f;     // How far down the ray goes
    public LayerMask targetLayer; // Filter which layers to hits
    Triggger particula;
     [SerializeField] ParticleSystem impacto = null;
     public void Raywizard()
    {
        // 1. Define the origin and direction
        Vector3 origin = topEmptyObject.position + (transform.forward * forwardOffset);
        Vector3 direction = transform.TransformDirection(Vector3.down);

        // 2. Variable to hold impact details
        RaycastHit hit;
        if (TryGetComponent<Collider>(out Collider col))
        {
            origin.y += col.bounds.extents.y;
        }
        // 3. Fire the raycast
        if (Physics.Raycast(origin, direction, out hit, rayLength, targetLayer))
        {
            
            
            impacto.transform.position = hit.point;
            

            // 4. Play the particle system
            if (!impacto.isPlaying)
            {
                impacto.Play();
            }
            
        }
    }
}