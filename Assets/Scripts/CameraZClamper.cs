using UnityEngine;

public sealed class CameraYLock : MonoBehaviour
{
    [Header("Batas Hold Ketinggian (Y)")]
    public float limitY = -0.7669286f; 

    // Pakai FixedUpdate atau LateUpdate, tapi kita tambahkan logika paksa
    void LateUpdate()
    {
        Vector3 currentPos = transform.position;

        if (currentPos.y < limitY)
        {
            // Paksa posisi ke batas yang ditentukan
            transform.position = new Vector3(currentPos.x, limitY, currentPos.z);
        }
    }
}