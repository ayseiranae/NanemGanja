using UnityEngine;

public class Seed : MonoBehaviour
{
    public ToolTrigger myToolTrigger;
    public Transform seedDropPoint;
    public LayerMask potLayer;

    void OnLeftTriggerPressed()
    {
        if (Physics.Raycast(seedDropPoint.position, Vector3.down, out RaycastHit hit, 2f, potLayer))
        {
            Debug.Log($"[Mechanics] Planting seed at {hit.collider.name}");
            myToolTrigger.PerformAction();
        }
        else
        {
            Debug.Log($"[Mechanics] No pot found");
        }
    }
}
