using System;
using UnityEngine;

public enum ActionType{
    None,
    PourSoil,
    PlantSeed,
    Water,
    Fertilize,
    Confirm
}

public static class GameEvents
{
    public static Action<int> OnWeekStarted;
    public static Action<ActionType> OnPlayerActionCompleted;
    public static Action OnSequenceFailed;
    public static Action OnWeekPassed;
}
