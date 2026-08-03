using UnityEngine;

public class DetectorSuperficie : MonoBehaviour
{
    private const string WalkableSurfaceTag = "WalkableSurface";

    public Collider superficieDetectada;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(WalkableSurfaceTag))
        {
            superficieDetectada = other;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(WalkableSurfaceTag))
        {
            superficieDetectada = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == superficieDetectada)
        {
            superficieDetectada = null;
        }
    }
}
