using RecipeConflict;

var recipeInfosAll = RecipeMapper.GetRecipes(@"H:\GTRecipes\assembly_line");
var recipeInfos = RecipeMapper.GetRecipes(@"H:\GTRecipes\provider1");
// RecipeMapper.PrintRecipes(recipeInfos);

var recipeInfoAsIntUniverse = RecipeMapper.ConvertRecipeInfoToInt(recipeInfosAll);
var recipeInfoAsInt = RecipeMapper.ConvertRecipeInfoToInt(recipeInfos);

// RecipeInfoAsInt.PrintRecipeInfoAsInt(recipeInfoAsInt);
if (RecipeConflictTools.Validate(recipeInfoAsInt,recipeInfoAsIntUniverse))
{
    Console.WriteLine("No conflict");
}