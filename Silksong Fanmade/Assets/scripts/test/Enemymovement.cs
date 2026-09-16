using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    

public float speed = 1;
    
private bool move = true;
    
    void Start() 
    {
    
    if (move) 
    {
      
    // the values in the brackets are for " x, y, z " 
    transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        
    }
    }

    public void OnCollisionEnter(Collision col)
    {
     if (col.gameObject.CompareTag("Player"))
     {
        move = false;
        
     }
    }

     public void OnCollisionExit(Collision col)
    {
     if (col.gameObject.CompareTag("Player"))
     {
         move = true;
     }
    }


    











}

    



