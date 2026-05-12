using UnityEngine;

public sealed class HandClamper : MonoBehaviour
{
    [Header("Batas Gerak Tangan")]
    [SerializeField] private float minZ = -50f;

    void LateUpdate()
    {
        // Ambil posisi lokal tangan terhadap Camera Offset
        Vector3 currentPos = transform.localPosition;

        // Paksa nilai Z agar tidak kurang dari -50
        currentPos.z = Mathf.Max(currentPos.z, minZ);

        // Terapkan posisi yang sudah dibatasi
        transform.localPosition = currentPos;
    }
}