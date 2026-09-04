using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoAtaque : MonoBehaviour
{
    public Transform Player;
    [SerializeField] raycaster rayw;
    [SerializeField] Hitpoints hp;
    private Rigidbody rb;
    private void OnEnable()
    {      
        rb = GetComponent<Rigidbody>();
        // hacer animacion de ataque

        // quitarle vida al chapulote
        hp.ChangeHealth(-2);
        // activar particulas de daño 
        rayw.Raywizard();
        Debug.Log("me mataste noo");
    }

    // Update is called once per frame
    void Update()
    {
        //mirar al player
        transform.LookAt(Player);

    
        
    }

    


}
