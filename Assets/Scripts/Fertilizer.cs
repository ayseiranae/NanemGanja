using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    public ToolTrigger myToolTrigger;
    public ParticleSystem fertilizeParticles;
    public Transform pourPoint;
    public LayerMask potLayer;

    void OnLeftTriggerPressed()
    {
        fertilizeParticles.Play();
        if (Physics.Raycast(pourPoint.position, Vector3.down, out RaycastHit hit, 2f, potLayer))
        {
            Debug.Log($"[Mechanics] Fertilizing pot at {hit.collider.name}");
            myToolTrigger.PerformAction();
        }
        else
        {
            Debug.Log($"[Mechanics] No pot found");
        }
    }

    void OnLeftTriggerReleased()
    {
        fertilizeParticles.Stop();
    }
}
