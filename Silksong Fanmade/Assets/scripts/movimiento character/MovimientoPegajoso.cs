using UnityEngine;

public class MovimientoPegajoso : MonoBehaviour
{
    public float speed = 8f;
    public float rotationSpeed = 10f;
    public float jumpForce = 7f;
    public float surfaceOffset = 0.05f;
    public float feetToOriginOffset = 1f;
    public float surfaceSearchDistance = 1.5f;

    public Rigidbody rb;
    public Collider superficieActual;
    public Vector3 normalSuperficie = Vector3.up;

    private void Awake()
    {
        rb = rb != null ? rb : GetComponentInParent<Rigidbody>();
    }

    public void Entrar(Collider nuevaSuperficie)
    {
        superficieActual = nuevaSuperficie;

        Transform cuerpo = rb.transform;
        Vector3 puntoCercano = superficieActual.ClosestPoint(cuerpo.position);
        Vector3 direccionHaciaSuperficie = puntoCercano - cuerpo.position;

        if (direccionHaciaSuperficie.sqrMagnitude <= 0.001f)
        {
            direccionHaciaSuperficie = -cuerpo.up;
        }

        Ray rayoEntrada = new Ray(cuerpo.position - direccionHaciaSuperficie.normalized * 0.25f, direccionHaciaSuperficie.normalized);

        if (superficieActual.Raycast(rayoEntrada, out RaycastHit hitEntrada, surfaceSearchDistance * 2f))
        {
            normalSuperficie = hitEntrada.normal;
            cuerpo.position = hitEntrada.point + normalSuperficie * (feetToOriginOffset + surfaceOffset);
        }
    }

    private void Update()
    {
        Transform cuerpo = rb.transform;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, normalSuperficie).normalized;
        Vector3 right = Vector3.ProjectOnPlane(Camera.main.transform.right, normalSuperficie).normalized;
        Vector3 direccion = Vector3.ClampMagnitude(right * horizontal + forward * vertical, 1f);

        Vector3 posicionObjetivo = cuerpo.position + direccion * speed * Time.deltaTime;
        Ray rayoSuperficie = new Ray(posicionObjetivo + normalSuperficie * surfaceSearchDistance, -normalSuperficie);

        superficieActual.Raycast(rayoSuperficie, out RaycastHit hit, surfaceSearchDistance * 2f);

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
}
