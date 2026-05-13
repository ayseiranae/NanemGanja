using UnityEngine;

public sealed class PositionClamper : MonoBehaviour
{
    // Kamu bisa atur batasnya di Inspector
    [SerializeField] private float minZ = -50f;

    void LateUpdate()
    {
        // Ambil posisi saat ini (local position terhadap Camera Offset)
        Vector3 currentPos = transform.localPosition;

        // Batasi nilai Z agar tidak kurang dari minZ
        currentPos.z = Mathf.Max(currentPos.z, minZ);

        // Terapkan kembali posisinya
        transform.localPosition = currentPos;
    }
}