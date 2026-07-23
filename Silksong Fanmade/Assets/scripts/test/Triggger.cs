using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggger : MonoBehaviour
{

    [SerializeField] raycaster rayw; 

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            Party();
        }
    }

    public void Party()
    {
        rayw.Raywizard();

    }
}
