using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAttacks : MonoBehaviour
{
    [SerializeField] Hitpoints hp;
    void OnCollision(Collider other) {
        if(other.CompareTag("AoE")){
            Debug.Log("Entered triggered with aoe");
            hp.ChangeHealth(-5);
        }
    }
}
