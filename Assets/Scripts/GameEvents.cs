using System;
using UnityEngine;

// JENIS JENIS AKSI YANG BISA DILAKUKAN PEMAIN
public enum ActionType
{
    None,
    PourSoil,
    PlantSeed,
    Water,
    Fertilize,
    Confirm
}

// JENIS EVENT YANG BISA TERJADI
public static class GameEvents
{
    public static Action<int> OnWeekStarted; // Mengirim angka minggu (1-8) 

    public static Action<ActionType> OnPlayerActionCompleted;

    // trigger event ketika player salah
    public static Action OnSequenceFailed;

    // trigger event ketika player sudah menyelesaikan task satu minggu
    public static Action OnWeekPassed;
}
