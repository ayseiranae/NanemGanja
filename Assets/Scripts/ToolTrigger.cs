using UnityEngine;

public class ToolTrigger : MonoBehaviour
{
    [Tooltip("Pilih jenis aksi yang dilakukan oleh alat tersebut")]
    public ActionType toolAction;

    // method ini dipanggil ketika player berhasil mengerjakan suatu aksi
    public void PerformAction()
    {
        Debug.Log($"[Mechanics] Player triggered: {toolAction}");
        GameEvents.OnPlayerActionCompleted?.Invoke(toolAction);
    }
}
