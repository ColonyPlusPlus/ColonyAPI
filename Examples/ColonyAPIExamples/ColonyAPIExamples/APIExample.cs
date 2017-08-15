using Pipliz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Players;

namespace ColonyAPIExamples
{
    [ModLoader.ModManager]
    public class APIExample
    {

        // Set the version (can be compared to a string "0.2.0" etc)
        public static Version modVersion = new Version(0, 2, 0);


        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, "ColonyAPIExample.AfterStartup")]
        [ModLoader.ModCallbackDependsOn("colonyapi.initialise")]
        public static void AfterStartup()
        {

            // Here you can add an update URL with the format: (MODNAME, URL)
            //ColonyAPI.Managers.VersionManager.addVersionURL("ColonyAPI-Example", "http://your.update.url/something.txt");

            // Then call the version check to compare the version to the URL response (ie: 0.1.0 -> Version(0,2,0))
            //ColonyAPI.Managers.VersionManager.runVersionCheck("ColonyPlusPlus-Core", modVersion);

            // this would initialise configuration, telling the API where to find a config file
            ColonyAPI.Managers.ConfigManager.registerConfig("ColonyAPIExample");
            
            // You can write to the log with this, specifying colour and font style
            ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPIExample", "Loaded Colony API Example v" + modVersion.ToString(), ColonyAPI.Helpers.Chat.ChatColour.yellow, ColonyAPI.Helpers.Chat.ChatStyle.normal);

        }


        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerConnectedLate, "ColonyAPIExample.OnPlayerConnectedLate")]
        public static void OnPlayerConnectedLate(Player p)
        {
            // If single palyer
            if (p.ID.steamID.m_SteamID == 0)
            {
                // sendSilent sends to the client, but not to the server log! Colors can be used too (and styles)
                ColonyAPI.Helpers.Chat.sendSilent(p, "Welcome to single player!", ColonyAPI.Helpers.Chat.ChatColour.red);
            }
            else
            {
                // this one is bold!
                ColonyAPI.Helpers.Chat.sendSilent(p, "Welcome to multiplayer!", ColonyAPI.Helpers.Chat.ChatColour.red, ColonyAPI.Helpers.Chat.ChatStyle.bold);
            }
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterAddingBaseTypes, "ColonyAPIExample.AfterAddingBaseTypes")]
        [ModLoader.ModCallbackProvidesFor("colonyapi.registerMaterials")]
        public static void RegisterMaterials()
        {

            // Register Materials
            // Create a material with the following parameters: name, albedo, emissive, heightmap, and normal
            ColonyAPI.Managers.MaterialManager.createMaterial("examplemat1", "grass", "neutral", "berrybush", "berrybush");
            ColonyAPI.Managers.MaterialManager.createMaterial("examplemat2", "planks", "neutral", "leavesTemperate", "leavesTemperate");

            // you can also replace materials that already exist (both in the base game and other mods if your registerMaterials
            ColonyAPI.Managers.MaterialManager.createMaterial("planks", "leavesTemperate", "neutral", "leavesTemperate", "leavesTemperate");
         


            ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPIExample", "Added Materials");
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterDefiningNPCTypes, "ColonyAPIExample.AddRecipeTypes")]
        [ModLoader.ModCallbackProvidesFor("colonyapi.AddRecipeTypes")]
        public static void DefineRecipeMappings()
        {
            // make sure any "crafting" recipes are mapped to the base game crafter! 
            ColonyAPI.Managers.JobManager.RegisterJobType("crafting", "pipliz.crafter");
        }
    }

    // register a block!

    // It must implement ColonyAPI.Classes.Type, AND the AutoType interface to be autoregistered by the API.
    class TestBlock : ColonyAPI.Classes.Type, ColonyAPI.Interfaces.IAutoType
    {
        public TestBlock() : base()
        {
            // using this.{property} you can address most/all block
            this.TypeName = "awesomeblock";
            this.OnRemoveAudio = "woodDeleteLight";
            this.OnPlaceAudio = "woodPlace";
            this.SideAll = "stonebricks";

            // our custom material!
            this.SideYPlus = "planks";
            this.NPCLimit = 0;
            this.IsPlaceable = true;
            this.AllowCreative = true;
            this.AllowPlayerCraft = true;

            // this will tell the API to bind the onAddAction() to this block!
            this.HasAddAction = true;
            this.Register();
        }

        // this function will automagically be called by the type registerer
        public override void AddRecipes()
        {
            // you can register a recipe like this

            //AddRecipe(type, requirements, results, if its NPC craftable, if its player craftable)
            ColonyAPI.Managers.RecipeManager.AddRecipe("crafting",
                // make a list of items
                new List<InventoryItem> {
                    // the name of the item, and the number
                    ColonyAPI.Managers.RecipeManager.Item("stonebricks", 12),
                    ColonyAPI.Managers.RecipeManager.Item("planks", 6)
                },
                new List<InventoryItem> {
                    ColonyAPI.Managers.RecipeManager.Item("awesomeblock", 1)
                }, true, true);
        }

        // this is the bound action as described above.
        public override void onAddAction(Vector3Int location, ushort type, Players.Player causedBy)
        {

            ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPIExample", causedBy.Name + " placed an awesome block!");
            base.onAddAction(location, type, causedBy);
        }
    }
}