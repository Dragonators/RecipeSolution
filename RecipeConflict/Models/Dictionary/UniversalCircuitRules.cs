using RecipeConflict.Models.Enums;

namespace RecipeConflict.Models.Dictionary;

public static partial class CircuitDictionary
{
    private static void AddUniversalRules()
    {
        for (int i = 0; i < Enum.GetNames(typeof(GTValues)).Length; i++)
            AddUniversal(i);
    }

    private static void AddUniversal(int gtValue)
    {
        ReplacementRules.Add($"kubejs:{(GTValues)gtValue}_universal_circuit",
            $"gtceu:circuits/{(GTValues)gtValue}");
    }
}