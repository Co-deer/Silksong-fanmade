using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
   public float speed = 1.5f;

    public Boolean interuptor = false;
  private Vector3 target;
 [SerializeField] ParticleSystem impact = null;
  void Start () {
      target = transform.position;

        impact.Play();
  }
  
  void Update () {
      if (Input.GetMouseButtonDown(0)) {
        interuptor = true;
        while(interuptor == true){
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        target.z = transform.position.z;

        impact.transform.position = target;
        }
        
      }
        if(Input.GetMouseButtonUp(0))
        {
            interuptor = false;
        }
      transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
  }





}

