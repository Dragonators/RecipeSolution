namespace RecipeConflict;

public class RecipeInfo
{
    public string Type { get; }
    public HashSet<string> Inputs { get; } = new HashSet<string>();
    public HashSet<string> Outputs { get; } = new HashSet<string>();

    public RecipeInfo(string type)
    {
        Type = type;
    }
}