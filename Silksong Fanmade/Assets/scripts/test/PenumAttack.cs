using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenumAttack : MonoBehaviour
{
    public Transform Enemy;
    [SerializeField] raycaster rayw;
    [SerializeField] Hitpoints hp;
    private Rigidbody rb;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp.ChangeHealth(-2);
            rayw.Raywizard();
        }
    }


    // Update is called once per frame
    void Update()
    {
        //mirar al player
        transform.LookAt(Enemy);
    }
}
