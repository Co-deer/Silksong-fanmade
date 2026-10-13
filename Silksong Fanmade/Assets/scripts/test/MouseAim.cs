using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    
    
    Plane plane;
    private float fDist = 5.0f;
    void Start ()
    {
       plane = new Plane(Vector3.forward, Vector3.zero);
       
	}

    void Update ()
    {
        
       if (Input.GetMouseButtonDown(0))
       {
        	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       	
       		plane.Raycast (ray, out fDist); 

       		transform.position = ray.GetPoint (fDist);
        }
            
       }

        
      
       
    }




