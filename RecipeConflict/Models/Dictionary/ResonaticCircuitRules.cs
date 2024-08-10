using RecipeConflict.Models.Enums;

namespace RecipeConflict.Models.Dictionary;

public static partial class CircuitDictionary
{
    private static void AddResonaticRules()
    {
        for (int i = 0; i < Enum.GetNames(typeof(GTValues)).Length; i++)
            AddResonatic(i);
    }

    private static void AddResonatic(int gtValue)
    {
        ReplacementRules.Add($"kubejs:circuit_resonatic_{(GTValues)gtValue}",
            $"gtceu:circuits/{(GTValues)gtValue}");
    }
}