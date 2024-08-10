using RecipeConflict.Models.Enums;

namespace RecipeConflict.Models.Dictionary;

public static partial class CircuitDictionary
{
    private static void AddSuprachronalRules()
    {
        for (int i = 0; i < Enum.GetNames(typeof(GTValues)).Length; i++)
            AddSuprachronal(i);
    }

    private static void AddSuprachronal(int gtValue)
    {
        ReplacementRules.Add($"kubejs:suprachronal_{(GTValues)gtValue}",
            $"gtceu:circuits/{(GTValues)gtValue}");
    }
}