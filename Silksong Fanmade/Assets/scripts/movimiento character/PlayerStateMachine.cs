using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum EstadoJugador
    {
        Normal,
        Pegado
    }

    public EstadoJugador estadoActual = EstadoJugador.Normal;

    public Rigidbody rb;
    public MovimientoNormal movimientoNormal;
    public MovimientoPegajoso movimientoPegajoso;
    public DetectorSuperficie detectorSuperficie;

    private void Awake()
    {
        rb = rb != null ? rb : GetComponentInParent<Rigidbody>();
        movimientoNormal = movimientoNormal != null ? movimientoNormal : GetComponent<MovimientoNormal>();
        movimientoPegajoso = movimientoPegajoso != null ? movimientoPegajoso : GetComponent<MovimientoPegajoso>();
        detectorSuperficie = detectorSuperficie != null ? detectorSuperficie : GetComponentInChildren<DetectorSuperficie>();
    }

    private void Start()
    {
        CambiarEstado(estadoActual);
    }

    private void Update()
    {
        if (estadoActual == EstadoJugador.Normal && detectorSuperficie.superficieDetectada != null)
        {
            CambiarEstado(EstadoJugador.Pegado);
        }

        if (estadoActual == EstadoJugador.Pegado && Input.GetButtonDown("Jump"))
        {
            Vector3 velocidadSalida = movimientoPegajoso.normalSuperficie * movimientoPegajoso.jumpForce;
            CambiarEstado(EstadoJugador.Normal);
            rb.velocity = velocidadSalida;
        }
    }

    public void CambiarEstado(EstadoJugador nuevoEstado)
    {
        estadoActual = nuevoEstado;

        movimientoNormal.enabled = nuevoEstado == EstadoJugador.Normal;
        movimientoPegajoso.enabled = nuevoEstado == EstadoJugador.Pegado;

        if (nuevoEstado == EstadoJugador.Normal)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            movimientoPegajoso.Entrar(detectorSuperficie.superficieDetectada);
        }
    }
}
