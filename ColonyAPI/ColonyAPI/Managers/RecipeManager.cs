using System;
using System.Collections.Generic;
using ColonyAPI.Classes;

namespace ColonyAPI.Managers
{
    public static class RecipeManager
    {

        // list of classes.recipe objects
        public static List<Classes.Recipe> recipeList = new List<Classes.Recipe>();
        public static List<Classes.Recipe> fueledRecipeList = new List<Classes.Recipe>();

        // List of all item classes, registered by the callback
        public static List<Classes.Type> TypesThatHaveRecipes = new List<Classes.Type>();

        // Keep a count of all added recipes (just to output to the user later)
        public static int recipesAdded = 0;

        //public static Dictionary<string, List<Recipe>> craftingRecipes = new Dictionary<string, List<Recipe>>();
        //public static Dictionary<string, List<RecipeFueled>> craftingRecipesFueled = new Dictionary<string, List<RecipeFueled>>();

        // Add a new recipe object to the list, this is called by the type's AddRecipes() function
        public static bool AddRecipe(string type, List<InventoryItem> reqs, List<InventoryItem> result, bool npcCraft = false, bool playerCraft = false)
        {
            //Utilities.WriteLog(ItemTypes.GetNamePrintable(result[0].Type));
            // Pass the variables
            Classes.Recipe r = new Classes.Recipe(type, reqs, result, npcCraft, playerCraft);

            // Add it to the list
            recipeList.Add(r);
            return true;
        }

        public static bool AddFueledRecipe(string type, List<InventoryItem> reqs, List<InventoryItem> result, float fuelAmount = 0.0f, bool npcCraft = false, bool playerCraft = false)
        {
            //Utilities.WriteLog(ItemTypes.GetNamePrintable(result[0].Type));
            // Pass the variables
            Classes.Recipe r = new Classes.Recipe(type, reqs, result, fuelAmount, npcCraft, playerCraft);

            // Add it to the list
            fueledRecipeList.Add(r);
            return true;
        }

        /// <summary>
        /// Build the recipe list using the callback registered class list
        /// </summary>
        public static void BuildRecipeList()
        {
            // Loop through
            foreach (Classes.Type t in TypesThatHaveRecipes)
            {
                // Add it :)
                t.AddRecipes();
            }
        }

        /// <summary>
        /// Process all these added recipes
        /// </summary>
        public static void ProcessRecipes()
        {
            Dictionary<string, List<global::Recipe>> RecipeMappings = new Dictionary<string, List<Recipe>>();
            Dictionary<string, List<global::RecipeFueled>> RecipeMappingsFueled = new Dictionary<string, List<RecipeFueled>>();

            int recipeCount = 0;
            int playerRecipeCount = 0;

            // Go through each registered recipe class
            foreach (Classes.Recipe RecipeInstance in recipeList)
            {
                recipeCount += 1;

                //Helpers.Utilities.WriteLog("ColonyAPI", "Loaded recipe for: " + RecipeInstance.Results[0].Type);

                if (RecipeInstance.PlayerCraftable == true)
                {
                    global::RecipePlayer.AllRecipes.Add(new global::Recipe(RecipeInstance.Requirements, RecipeInstance.Results));
                    playerRecipeCount += 1;
                }

                if (RecipeMappings.ContainsKey(RecipeInstance.Type.ToLower()))
                {
                    RecipeMappings[RecipeInstance.Type.ToLower()].Add(new global::Recipe(RecipeInstance.Requirements, RecipeInstance.Results));
                }
                else
                {
                    RecipeMappings.Add(RecipeInstance.Type.ToLower(), new List<Recipe>() { new global::Recipe(RecipeInstance.Requirements, RecipeInstance.Results) });
                }

            }

            foreach (string craftingtype in RecipeMappings.Keys)
            {
                if (JobManager.JobRecipeMappings.ContainsKey(craftingtype))
                {
                    Pipliz.APIProvider.Recipes.RecipeManager.AddRecipes(JobManager.JobRecipeMappings[craftingtype], RecipeMappings[craftingtype]);
                    Helpers.Utilities.WriteLog("ColonyAPI", "Registered recipes for job [" + JobManager.JobRecipeMappings[craftingtype] + "]");
                }
            }

            // Go through each registered recipe class
            foreach (Classes.Recipe RecipeInstance in fueledRecipeList)
            {
                recipeCount += 1;
                

                if (RecipeMappingsFueled.ContainsKey(RecipeInstance.Type.ToLower()))
                {
                    RecipeMappingsFueled[RecipeInstance.Type.ToLower()].Add(new global::RecipeFueled(RecipeInstance.FuelCost, RecipeInstance.Requirements, RecipeInstance.Results));
                }
                else
                {
                    RecipeMappingsFueled.Add(RecipeInstance.Type.ToLower(), new List<RecipeFueled>() { new global::RecipeFueled(RecipeInstance.FuelCost, RecipeInstance.Requirements, RecipeInstance.Results) });
                }

            }

            foreach (string craftingtype in RecipeMappingsFueled.Keys)
            {
                if (JobManager.JobRecipeMappings.ContainsKey(craftingtype))
                {
                    Pipliz.APIProvider.Recipes.RecipeManager.AddRecipesFueled(JobManager.JobRecipeMappings[craftingtype], RecipeMappingsFueled[craftingtype]);
                    Helpers.Utilities.WriteLog("ColonyAPI", "Registered fueled recipes for job [" + JobManager.JobRecipeMappings[craftingtype] + "]");
                }
            }



            Helpers.Utilities.WriteLog("ColonyAPI", "Registered " + playerRecipeCount + " player recipes");
            Helpers.Utilities.WriteLog("ColonyAPI", "Registered " + recipeCount + " total recipes");
        }

        /// <summary>
        /// Just a function that performs the item lookup nicely
        /// </summary>
        /// <param name="name">Item name (as it is registered)</param>
        /// <param name="num">The number the inventory should contain</param>
        /// <returns></returns>
        public static InventoryItem Item(string name, int num)
        {
            /*try
            {
                ushort u;
                ItemTypes.IndexLookup.TryGetIndex(name, out u);
                InventoryItem i = new InventoryItem(u, num);
                return i;
            } catch (Exception e)
            {
                Utilities.WriteLog("Error finding " + name);
            }

            return new InventoryItem(0, 0);
            */
            return new InventoryItem(ItemTypes.IndexLookup.GetIndex(name), num);
        }
    }
}
