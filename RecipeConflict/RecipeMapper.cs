using System.Text.Json;
using RecipeConflict.Map;
using RecipeConflict.Models.Dictionary;
using RecipeConflict.Models.Json;

namespace RecipeConflict;

public class RecipeMapper
{
    public static List<RecipeInfo> GetRecipes(string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath, "*.json");
        var recipes = new List<RecipeInfo>();
        foreach (var file in files)
        {
            using FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            var recipe = JsonSerializer.Deserialize<GtceuRecipe>(stream,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var recipeInfo = new RecipeInfo(recipe!.Type);

            //Recipe Inputs
            recipeInfo.Inputs.UnionWith((recipe.Inputs.Fluid?
                .SelectMany(fluid => fluid.Content.Value
                    .Select(v => new[]
                    {
                        v.Fluid, v.Tag
                    }))
                .SelectMany(prop => prop)
                .Where(prop => !string.IsNullOrEmpty(prop)) ?? Array.Empty<string>()).ToHashSet()!);
            recipeInfo.Inputs.UnionWith((recipe.Inputs.Item?
                .SelectMany(item => new[]
                {
                    item.Content.Ingredient.Item is null
                        ? null
                        : CircuitDictionary.ReplacementRules.TryGetValue(item.Content.Ingredient.Item,
                            out var replacement)
                            ? replacement
                            : item.Content.Ingredient.Item,
                    item.Content.Ingredient.Tag
                })
                .Where(prop => !string.IsNullOrEmpty(prop)) ?? Array.Empty<string>()).ToHashSet()!);

            //Recipe Outputs
            recipeInfo.Outputs.UnionWith((recipe.Outputs.Fluid?
                .SelectMany(fluid => fluid.Content.Value.Select(v => v.Fluid)) ?? Array.Empty<string>()).ToHashSet()!);
            recipeInfo.Outputs.UnionWith((recipe.Outputs.Item?
                .Select(item => item.Content.Ingredient.Item) ?? Array.Empty<string>()).ToHashSet()!);

            recipes.Add(recipeInfo);
        }

        return recipes;
    }

    public static void PrintRecipes(IEnumerable<RecipeInfo> recipes)
    {
        foreach (var recipe in recipes)
        {
            Console.WriteLine("Type: " + recipe.Type);
            Console.WriteLine("Inputs: " + string.Join(", ", recipe.Inputs));
            Console.WriteLine("Outputs: " + string.Join(", ", recipe.Outputs));
            Console.WriteLine();
        }
    }

    public static List<RecipeInfoAsInt> ConvertRecipeInfoToInt(List<RecipeInfo> recipeInfos)
    {
        //Add convert rules
        //Return a list of results
        var result = new List<RecipeInfoAsInt>();
        var i = ItemMap.Map.Count;
        var j = RecipeMap.Map.Count;
        foreach (var recipeInfo in recipeInfos)
        {
            if (!RecipeMap.Map.ContainsValue(recipeInfo.Outputs)) RecipeMap.Map.Add(j++, recipeInfo.Outputs);
            result.Add(
                new RecipeInfoAsInt
                {
                    RecipeKey = RecipeMap.Map.First(recipe => recipe.Value == recipeInfo.Outputs).Key
                });

            foreach (var input in recipeInfo.Inputs)
            {
                if (!ItemMap.Map.ContainsValue(input)) ItemMap.Map.Add(i++, input);
                result.Last().InputKeys.Add(ItemMap.Map.First(item => item.Value == input).Key);
            }
        }

        return result;
    }
}