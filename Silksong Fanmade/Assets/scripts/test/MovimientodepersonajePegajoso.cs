using UnityEngine;

public class MovimientodepersonajePegajoso : MonoBehaviour
{
    public enum EstadoMovimiento
    {
        Normal,
        Pegado
    }

    public float speed = 8f;
    public float rotationSpeed = 10f;
    public float jumpForce = 7f;
    public float surfaceOffset = 0.05f;
    public float feetToOriginOffset = 1f;
    public float surfaceSearchDistance = 1.5f;

    private const string WalkableSurfaceTag = "WalkableSurface";

    public Rigidbody rb;
    public EstadoMovimiento estado = EstadoMovimiento.Normal;
    public Collider superficieDetectada;
    public Vector3 normalSuperficie = Vector3.up;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (rb == null)
        {
            rb = GetComponentInParent<Rigidbody>();
        }
    }

    private void Update()
    {
        if (rb == null)
        {
            return;
        }

        Transform cuerpo = rb.transform;

        if (estado != EstadoMovimiento.Pegado)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            estado = EstadoMovimiento.Normal;
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.velocity = normalSuperficie * jumpForce;
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, normalSuperficie).normalized;
        Vector3 right = Vector3.ProjectOnPlane(Camera.main.transform.right, normalSuperficie).normalized;
        Vector3 direccion = Vector3.ClampMagnitude(right * horizontal + forward * vertical, 1f);

        Vector3 posicionObjetivo = cuerpo.position + direccion * speed * Time.deltaTime;
        Ray rayoSuperficie = new Ray(posicionObjetivo + normalSuperficie * surfaceSearchDistance, -normalSuperficie);

        if (!superficieDetectada.Raycast(rayoSuperficie, out RaycastHit hit, surfaceSearchDistance * 2f))
        {
            estado = EstadoMovimiento.Normal;
            rb.isKinematic = false;
            rb.useGravity = true;
            return;
        }

        normalSuperficie = hit.normal;
        direccion = Vector3.ProjectOnPlane(direccion, normalSuperficie).normalized * direccion.magnitude;
        cuerpo.position = hit.point + normalSuperficie * (feetToOriginOffset + surfaceOffset);

        Vector3 direccionMirada = direccion.sqrMagnitude > 0.01f
            ? direccion
            : Vector3.ProjectOnPlane(cuerpo.forward, normalSuperficie).normalized;

        cuerpo.rotation = Quaternion.Slerp(
            cuerpo.rotation,
            Quaternion.LookRotation(direccionMirada, normalSuperficie),
            rotationSpeed * Time.deltaTime
        );
    }

    private void FixedUpdate()
    {
        if (rb == null)
        {
            return;
        }

        if (estado != EstadoMovimiento.Normal)
        {
            return;
        }

        Transform cuerpo = rb.transform;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = Camera.main.transform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 direccion = Vector3.ClampMagnitude(right * horizontal + forward * vertical, 1f);

        Vector3 velocidadHorizontal = direccion * speed;
        rb.velocity = new Vector3(velocidadHorizontal.x, rb.velocity.y, velocidadHorizontal.z);

        if (direccion.sqrMagnitude > 0.01f)
        {
            cuerpo.rotation = Quaternion.Slerp(
                cuerpo.rotation,
                Quaternion.LookRotation(direccion, Vector3.up),
                rotationSpeed * Time.fixedDeltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(WalkableSurfaceTag))
        {
            superficieDetectada = other;
            EntrarPegado();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(WalkableSurfaceTag))
        {
            superficieDetectada = other;

            if (estado == EstadoMovimiento.Normal)
            {
                EntrarPegado();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == superficieDetectada)
        {
            superficieDetectada = null;
        }
    }

    private void EntrarPegado()
    {
        if (rb == null || superficieDetectada == null)
        {
            return;
        }

        Transform cuerpo = rb.transform;
        Vector3 puntoCercano = superficieDetectada.ClosestPoint(cuerpo.position);
        Vector3 direccionHaciaSuperficie = puntoCercano - cuerpo.position;

        if (direccionHaciaSuperficie.sqrMagnitude <= 0.001f)
        {
            direccionHaciaSuperficie = -cuerpo.up;
        }

        Ray rayoEntrada = new Ray(cuerpo.position - direccionHaciaSuperficie.normalized * 0.25f, direccionHaciaSuperficie.normalized);

        if (superficieDetectada.Raycast(rayoEntrada, out RaycastHit hitEntrada, surfaceSearchDistance * 2f))
        {
            normalSuperficie = hitEntrada.normal;
            cuerpo.position = hitEntrada.point + normalSuperficie * (feetToOriginOffset + surfaceOffset);
        }

        estado = EstadoMovimiento.Pegado;
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }
}
