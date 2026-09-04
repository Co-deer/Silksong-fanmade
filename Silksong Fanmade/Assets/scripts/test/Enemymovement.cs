using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    

public float speed;
    
public bool move = true;
    
    void Update() 
    {
    
    if (move) 
    {
    // the values in the brackets are for " x, y, z " 
    transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }
    }

    public void OnCollisionEnter(Collision col)
    {
     if (col.gameObject.name == "player")
     {
        move = false;
     }
    }

     public void OnCollisionExit(Collision col)
    {
     if (col.gameObject.name == "player")
     {
         move = true;
     }
    }


    











}

    



