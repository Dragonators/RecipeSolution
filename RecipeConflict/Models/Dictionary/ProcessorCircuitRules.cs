using RecipeConflict.Models.Enums;

namespace RecipeConflict.Models.Dictionary;

public static partial class CircuitDictionary
{
    private static void AddProcessorRules()
    {
        AddProcessor("micro", "mv");
        AddProcessor("nano", "hv");
        AddProcessor("quantum", "ev");
        AddProcessor("crystal", "iv");
        AddProcessor("wetware", "luv");
        AddProcessor("bioware", "zpm", true);
        AddProcessor("optical", "uv", true);
        AddProcessor("exotic", "uhv", true);
        AddProcessor("cosmic", "uev", true);
        AddProcessor("supracausal", "uiv", true);
    }

    private static void AddProcessor(string baseName, string baseGtValue, bool isKubeJs = false)
    {
        if (Enum.TryParse(baseGtValue, true, out GTValues baseValue))
        {
            var prefix = isKubeJs ? "kubejs" : "gtceu";
            ReplacementRules.Add($"{prefix}:{baseName}_processor",
                $"gtceu:circuits/{Enum.GetName(typeof(GTValues), (int)baseValue)}");
            ReplacementRules.Add($"{prefix}:{baseName}_processor_assembly",
                $"gtceu:circuits/{Enum.GetName(typeof(GTValues), (int)baseValue + 1)}");
            ReplacementRules.Add($"{prefix}:{baseName}_processor_computer",
                $"gtceu:circuits/{Enum.GetName(typeof(GTValues), (int)baseValue + 2)}");
            ReplacementRules.Add($"{prefix}:{baseName}_processor_mainframe",
                $"gtceu:circuits/{Enum.GetName(typeof(GTValues), (int)baseValue + 3)}");
        }
        else
        {
            throw new ArgumentException($"'{baseGtValue}' 不是有效的枚举值");
        }
    }
}