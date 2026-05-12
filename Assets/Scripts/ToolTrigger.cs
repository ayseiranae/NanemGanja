using UnityEngine;

public class ToolTrigger : MonoBehaviour
{
    [Tooltip("Pilih")]
    public ActionType toolAction;

    public void PerformAction()
    {
        Debug.Log($" [Mechanics] Player triggered: {toolAction}");
        GameEvents.OnPlayerActionCompleted?.Invoke(toolAction);
    }
}