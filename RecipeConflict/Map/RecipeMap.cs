namespace RecipeConflict.Map;

public static class RecipeMap
{
    public static Dictionary<int, HashSet<string>> Map { get; } = new Dictionary<int, HashSet<string>>();
}