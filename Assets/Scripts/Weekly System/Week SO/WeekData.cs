using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeekData", menuName = "Scriptable Objects/WeekData")]
public class WeekData : ScriptableObject
{
    public int weekNumber;
    public List<ActionType> requiredSequence; // e.g., [PourSoil, PlantSeed, Confirm] for Week 1
    public bool hasHints; // buat nentuin di week itu ditunjukin Hint ato ngga
}
