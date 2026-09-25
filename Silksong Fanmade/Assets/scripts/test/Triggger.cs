using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggger : MonoBehaviour
{

    [SerializeField] raycaster rayw = null; 
    [SerializeField] Skill2 s2 = null;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            //Party();
            rayw.Raywizard();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
           //SecondParty();
           s2.Raywizard();
        }
    }

    /*
    public void Party()
    {
        rayw.Raywizard();

    }

    public void SecondParty()
    {
        s2.Raywizard();

    }
    */
}
