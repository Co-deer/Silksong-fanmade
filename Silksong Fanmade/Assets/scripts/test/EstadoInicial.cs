using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoInicial : MonoBehaviour
{

    private MaquinaDeEstados maquinaDeEstados;
    // Start is called before the first frame update
    void Start()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            maquinaDeEstados.ActivarEstado(
                maquinaDeEstados.EstadoPersecucion
            );
        }
    }
}
