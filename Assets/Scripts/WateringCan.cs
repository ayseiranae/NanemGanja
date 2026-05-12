using UnityEngine;

public class WateringCanMechanic : MonoBehaviour
{
    public ToolTrigger myToolTrigger;
    public ParticleSystem waterParticles;
    public Transform spoutTransform;
    public LayerMask potLayer;

    void OnLeftTriggerPressed()
    {
        waterParticles.Play();
        if (Physics.Raycast(spoutTransform.position, Vector3.down, out RaycastHit hit, 2f, potLayer))
        {
            Debug.Log($"[Mechanics] Watering pot at {hit.collider.name}");
            myToolTrigger.PerformAction();
        }
        else
        {
            Debug.Log($"[Mechanics] No pot found");
        }
    }

    void OnLeftTriggerReleased()
    {
        waterParticles.Stop();
    }
}
