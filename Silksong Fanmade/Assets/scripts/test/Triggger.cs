using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggger : MonoBehaviour
{

    [SerializeField] raycaster rayw; 
    [SerializeField] Skill2 s2;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {

            Party();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
           SecondParty();
        }
    }

    public void Party()
    {
        rayw.Raywizard();

    }

     public void SecondParty()
    {
        s2.Effect();

    }
}
