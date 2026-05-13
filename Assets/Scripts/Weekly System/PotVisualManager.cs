using UnityEngine;

public class PotVisualManager : MonoBehaviour
{
    [Header("Growth Stages (Prefabs)")]
    [Tooltip("Masukkan 8 Prefab visual tanaman secara berurutan.")]
    public GameObject[] growthStagePrefabs;

    [Header("Spawn Settings")]
    [Tooltip("Titik kemunculan tanaman (bisa gunakan Transform dari objek Pot ini sendiri)")]
    public Transform spawnPoint;

    // lacak tanaman mana yang sedang muncul di scene saat ini
    private GameObject currentPlantInstance;

    // 1. Subscribe/unsub ke Event System
    private void OnEnable()
    {
        GameEvents.OnWeekStarted += UpdateVisualForWeek;
    }

    private void OnDisable()
    {
        GameEvents.OnWeekStarted -= UpdateVisualForWeek;
    }

    // Saat minggu berubah
    private void UpdateVisualForWeek(int currentWeek)
    {
        Debug.Log($"[Visual Manager] Memperbarui tampilan untuk Week {currentWeek}");

        // Hancurkan (Destroy) model tanaman dari minggu sebelumnya jika ada
        if (currentPlantInstance != null)
        {
            Destroy(currentPlantInstance);
        }

        int arrayIndex = currentWeek - 1;

        if (arrayIndex >= 0 && arrayIndex < growthStagePrefabs.Length)
        {
            // Munculkan (Instantiate) Prefab yang sesuai dengan minggu saat ini
            if (growthStagePrefabs[arrayIndex] != null)
            {
                // Instantiate membuat clone dari prefab di posisi dan rotasi spawnPoint
                currentPlantInstance = Instantiate(growthStagePrefabs[arrayIndex], spawnPoint.position, spawnPoint.rotation);

                // (Opsional) Jadikan spawnPoint sebagai parent agar Hierarchy tetap rapi
                currentPlantInstance.transform.SetParent(spawnPoint);
            }
        }
        else
        {
            Debug.LogWarning($"[Visual Manager] Tidak ada prefab yang disiapkan untuk Week {currentWeek}");
        }
    }
}
