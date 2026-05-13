using System.Collections.Generic;
using UnityEngine;



public class SequenceValidator : MonoBehaviour
{
    [Header("Game Progression Settings")]
    [Tooltip("Masukkan daftar urutan dari Week 1 sampai Week 8 di sini")]
    public List<WeekData> allWeeksData;
    [Header("Read Only")]
    public int currentWeek = 1;
    private int currentStepIndex = 0;

    // sub/unsub event buat performance optimization (prevent memory leak)
    private void OnEnable()
    {
        GameEvents.OnPlayerActionCompleted += CheckActionSequence;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerActionCompleted -= CheckActionSequence;
    }

    // Panggil saat game baru mulai
    private void Start()
    {
        GameEvents.OnWeekStarted?.Invoke(currentWeek);
    }

    private void CheckActionSequence(ActionType receivedAction)
    {
        List<ActionType> requiredSequence = currentWeek - 1 < allWeeksData.Count ? allWeeksData[currentWeek - 1].requiredSequence : new List<ActionType>();
        if (requiredSequence == null || requiredSequence.Count == 0) return;
        Debug.Log("Received action {receivedAction}. Checking against required sequence for Week " + currentWeek);

        // cek aksinya sesuai dengan step saat ini ngga
        if (receivedAction == requiredSequence[currentStepIndex])
        {
            Debug.Log($"Correct! Step {currentStepIndex + 1} of {requiredSequence.Count} done.");
            currentStepIndex++;

            // cek task sequence nya udah abis ngga
            if (currentStepIndex >= requiredSequence.Count)
            {
                Debug.Log($"[Logic] Week {currentWeek} Passed!");
                GameEvents.OnWeekPassed?.Invoke();

                // Lanjut ke minggu berikutnya
                currentWeek++;
                currentStepIndex = 0; // Reset langkah untuk minggu depan

                // Beritahu sistem visual (PlantVisualManager) untuk mengganti model tanaman
                GameEvents.OnWeekStarted?.Invoke(currentWeek);

                // Cek apakah game tamat (sudah melewati minggu terakhir)
                if (currentWeek > allWeeksData.Count)
                {
                    Debug.Log("[Logic] SELAMAT! Kamu telah menyelesaikan Week 8");
                }
            }
        }
        else
        {
            // The player made a mistake
            Debug.Log($"[Logic] WRONG ACTION! Expected {requiredSequence[currentStepIndex]}, but got {receivedAction}. Resetting to Week 1...");

            GameEvents.OnSequenceFailed?.Invoke();
            currentWeek = 1;
            currentStepIndex = 0;

            // Beritahu visual manager untuk mengembalikan pot ke bentuk semula (kosong)
            GameEvents.OnWeekStarted?.Invoke(currentWeek);
        }
    }
}

