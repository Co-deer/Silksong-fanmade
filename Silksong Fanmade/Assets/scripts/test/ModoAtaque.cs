using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoAtaque : MonoBehaviour
{
    public Transform Player;
    [SerializeField] raycaster rayw;
    [SerializeField] Hitpoints hp;
    private Rigidbody rb;
    Collider GetCollider;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hp.ChangeHealth(-2);
            rayw.Raywizard();
        }
    }


    // Update is called once per frame
    void Update()
    {
        //mirar al player
        transform.LookAt(Player);
    }

    


}
