// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace RecipeConflict.Models.Json;

public class Ingredient
{
    public string? Item { get; set; } //specific item
    public string? Tag { get; set; } //alternative item
}

public class ItemContent
{
    public Ingredient Ingredient { get; set; } = null!;
}

public class Item
{
    public ItemContent Content { get; set; } = null!;
}

public class Value
{
    public string? Fluid { get; set; }
    public string? Tag { get; set; }
}

public class FluidContent
{
    public List<Value> Value { get; set; } = null!;
}

public class Fluid
{
    public FluidContent Content { get; set; } = null!;
}

public class Inputs
{
    public List<Item>? Item { get; set; }
    public List<Fluid>? Fluid { get; set; }
}

public class Outputs
{
    public List<Item>? Item { get; set; }
    public List<Fluid>? Fluid { get; set; }
}

public class GtceuRecipe
{
    public string Type { get; set; } = null!;
    public Inputs Inputs { get; set; } = null!;
    public Outputs Outputs { get; set; } = null!;
}