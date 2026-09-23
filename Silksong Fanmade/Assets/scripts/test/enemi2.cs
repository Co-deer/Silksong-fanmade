using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemi2 : MonoBehaviour
{
    private MaquinaDeEstados maquinaDeEstados;
    public Transform Player;

public int MoveSpeed = 4;
public int MaxDist = 6;
public int MinDist = 3;

public void Start()
{
    maquinaDeEstados = GetComponent<MaquinaDeEstados>();
    
}

public void Update()
{
    transform.LookAt(Player);

    if (Vector3.Distance(transform.position, Player.position) >= MinDist)
    {

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAtaque);
             Debug.Log("estado de ataque activado");
             MoveSpeed = 0;
        }

    }
}
}
