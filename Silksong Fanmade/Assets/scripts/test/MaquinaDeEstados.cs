using UnityEngine;
using System.Collections;

public class MaquinaDeEstados : MonoBehaviour {

    
    public MonoBehaviour EstadoAtaque;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoInicial;


    private MonoBehaviour estadoActual;

    void Start () {
        ActivarEstado(EstadoInicial);
	}
	
    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if(estadoActual!=null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }

}
