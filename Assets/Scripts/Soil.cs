using UnityEngine;

public class Soil : MonoBehaviour
{
    public ToolTrigger myToolTrigger;
    public ParticleSystem soilParticles;
    public Transform pourPoint;
    public LayerMask potLayer;

    void OnLeftTriggerPressed()
    {
        soilParticles.Play();
        if (Physics.Raycast(pourPoint.position, Vector3.down, out RaycastHit hit, 2f, potLayer))
        {
            Debug.Log($"[Mechanics] Pouring soil at {hit.collider.name}");
            myToolTrigger.PerformAction();
        }
        else
        {
            Debug.Log($"[Mechanics] No pot found");
        }
    }

    void OnLeftTriggerReleased()
    {
        soilParticles.Stop();
    }
}
