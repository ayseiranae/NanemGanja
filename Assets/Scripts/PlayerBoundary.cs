using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    [Header("Batasan X (Kiri - Kanan)")]
    public float minX = -2.5f;
    public float maxX = 16f;

    [Header("Batasan Z (Mundur - Maju)")]
    public float minZ = -10f;
    public float maxZ = 20f;

    private CharacterController characterController;

    void Start()
    {
        // Mencoba mendapatkan komponen Character Controller jika ada
        characterController = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        // Mengecek apakah posisi pemain keluar dari batas
        bool isOutOfBounds = pos.x < minX || pos.x > maxX || pos.z < minZ || pos.z > maxZ;

        if (isOutOfBounds)
        {
            // Menentukan posisi baru yang sudah dibatasi (clamped)
            float clampedX = Mathf.Clamp(pos.x, minX, maxX);
            float clampedZ = Mathf.Clamp(pos.z, minZ, maxZ);
            Vector3 clampedPosition = new Vector3(clampedX, pos.y, clampedZ);

            if (characterController != null && characterController.enabled)
            {
                // Jika pakai Character Controller, kita perlu mematikan sebentar agar posisinya bisa dipaksa pindah
                characterController.enabled = false;
                transform.position = clampedPosition;
                characterController.enabled = true;
            }
            else
            {
                // Jika tidak pakai Character Controller, langsung ubah transform-nya
                transform.position = clampedPosition;
            }
        }
    }
}
