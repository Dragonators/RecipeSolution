namespace RecipeConflict.Models.Dictionary;

public static partial class CircuitDictionary
{
    public static Dictionary<string, string> ReplacementRules { get; private set; }

    static CircuitDictionary()
    {
        ReplacementRules = new Dictionary<string, string>();

        // Add Processors
        AddProcessorRules();

        // Add Suprachronal
        AddSuprachronalRules();

        // Add Resonatic
        AddResonaticRules();

        // Add Universal
        AddUniversalRules();
    }
}