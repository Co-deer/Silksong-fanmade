using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAttacks : MonoBehaviour
{
    public bool isInBox;

void Update(){
    if(isInBox){
       
    } else {
        
    }
}

void OnTriggerStay(Collider other){
    if(other.CompareTag("Player"))
    {
        isInBox = true;
    }
}
void OnTriggerExit(Collider other){
    if(other.CompareTag("Player")){
        isInBox = false;
    }
}
}
