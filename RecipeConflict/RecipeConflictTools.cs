using RecipeConflict.Map;

namespace RecipeConflict;

public class RecipeConflictTools
{
    public static bool Validate(List<RecipeInfoAsInt> recipes, List<RecipeInfoAsInt> universeRecipes)
    {
        var sets = recipes.Select(r => r.InputKeys).ToList();
        var universe = universeRecipes.Select(r => r.InputKeys).ToList();
        for (int i = 0; i < universe.Count; i++)
        {
            var unionSet = sets.Where(s => !s.SetEquals(universe[i])).SelectMany(s => s).ToHashSet();
            if (universe[i].IsSubsetOf(unionSet))
            {
                PrintConlictInfo(universeRecipes, i);
                return false;
            }
        }

        return true;
    }

    private static Dictionary<int, HashSet<int>> GetConflictInfo(List<RecipeInfoAsInt> recipes, int index)
    {
        //int => itemKey
        //HashSet<int> => RecipeKeys
        var conflictDict = new Dictionary<int, HashSet<int>>();
        var inputs = recipes[index].InputKeys;

        foreach (var input in inputs)
        {
            conflictDict.Add(input, new HashSet<int>());
            for (int i = 0; i < recipes.Count; i++)
            {
                if (i != index && recipes[i].InputKeys.Contains(input))
                    conflictDict[input].Add(i);
            }
        }

        return conflictDict;
    }

    public static void PrintConlictInfo(List<RecipeInfoAsInt> recipes, int index)
    {
        Console.WriteLine($"Possible Recipe Result: {RecipeMap.Map[recipes[index].RecipeKey].First()},");

        var conflictInfo = GetConflictInfo(recipes, index);
        foreach (var kvp in conflictInfo)
        {
            var recipeValue = new HashSet<string>();
            foreach (var recipeKey in kvp.Value)
            {
                recipeValue.UnionWith(RecipeMap.Map[recipeKey]);
            }

            // Console.WriteLine($"Item: {ItemMap.Map[kvp.Key]}, Conflict with: {string.Join(", ", recipeValue)}");
            Console.WriteLine($"Item: {ItemMap.Map[kvp.Key]}, Conflict with:");
            Console.WriteLine("{");
            Console.Write(string.Join("," + Environment.NewLine, recipeValue.Select(output => $"\toutput: {output}")));
            Console.WriteLine("");
            Console.WriteLine("}");
        }
    }
}