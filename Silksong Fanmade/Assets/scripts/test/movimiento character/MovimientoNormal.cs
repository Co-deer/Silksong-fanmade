using UnityEngine;

public class MovimientoNormal : MonoBehaviour
{
    public float speed = 8f;
    public float rotationSpeed = 10f;
    public Rigidbody rb;

    private void Awake()
    {
        rb = rb != null ? rb : GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
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
}
