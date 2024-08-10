namespace RecipeConflict;

public class RecipeInfoAsInt
{
    public int RecipeKey { get; set; }
    public HashSet<int> InputKeys { get; } = new HashSet<int>();

    public static void PrintRecipeInfoAsInt(List<RecipeInfoAsInt> recipes)
    {
        foreach (var recipeInfoAsInt in recipes)
        {
            Console.WriteLine($"RecipeKey: {recipeInfoAsInt.RecipeKey}");
            Console.WriteLine($"InputKeys: {string.Join(", ", recipeInfoAsInt.InputKeys)}");
        }
    }
}