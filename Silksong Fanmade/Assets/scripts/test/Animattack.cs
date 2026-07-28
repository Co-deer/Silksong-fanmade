using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animattack : MonoBehaviour
{
    
    private Animator anim;
 
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (anim != null)
        {
            
            
        
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

        }
    }
}
