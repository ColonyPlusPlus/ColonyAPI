using Pipliz.Chatting;
using static Players;
using System;
using System.Collections.Generic;

namespace ColonyAPI
{
    [ModLoader.ModManager]
    public class ColonyAPIBase
    {

        public static Version APIVersion = new Version(0, 1, 0);


        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, "colonyapi.AfterStartup")]
        public static void AfterStartup()
        {
            Helpers.Utilities.WriteLog("ColonyAPI", "Initialising ColonyAPI v" + APIVersion.ToString(3), Helpers.Chat.ChatColour.cyan, Helpers.Chat.ChatStyle.bold);

            Helpers.ServerVariableParser.init();

            Temporary.BaseGameMaterialManager.initialiseMaterials();

            // Initialize chat commands
            Managers.ChatCommandManager.Initialize();

        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerConnectedLate, "colonyapi.OnPlayerConnectedLate")]
        public static void OnPlayerConnectedLate(Player p)
        {
            
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterAddingBaseTypes, "colonyapi.AfterAddingBaseTypes")]
        public static void AfterAddingBaseTypes()
        {
            Helpers.Utilities.WriteLog("ColonyAPI", "Starting Master AfterAddingBaseTypes");

            
            Managers.MaterialManager.registerMaterials();

            Managers.TypeManager.autoDiscoverTypes();
            Managers.TypeManager.processTypeRegistration();

            Helpers.Utilities.WriteLog("ColonyAPI", "Ending Master AfterAddingBaseTypes");
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterItemTypesServer, "colonyapi.AfterItemTypesServer")]
        public static void AfterItemTypesServer()
        {
            // Regsiter types with actions
            Managers.TypeManager.registerActionableTypes();

            // Register Master Command
            ChatCommands.CommandManager.RegisterCommand(new Managers.MasterChatCommandManager());
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterWorldLoad, "colonyapi.AfterWorldLoad")]
        public static void AfterWorldLoad()
        {
            
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnUpdate, "colonyapi.OnUpdate")]
        public static void OnUpdate()
        {
           
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnQuitEarly, "colonyapi.OnQuitEarly")]
        public static void OnQuitEarly()
        {
           
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnQuit, "colonyapi.OnQuit")]
        public static void OnQuit()
        {
           
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterDefiningNPCTypes, "colonyapi.AfterDefiningNPCTypes")]
        [ModLoader.ModCallbackProvidesFor("pipliz.apiprovider.jobs.resolvetypes")]
        public static void AfterDefiningNPCTypes()
        {
           
        
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterItemTypesDefined, "colonyapi.AfterItemTypesDefined")]
        [ModLoader.ModCallbackDependsOn("pipliz.blocknpcs.loadrecipes")]
        [ModLoader.ModCallbackProvidesFor("pipliz.apiprovider.registerrecipes")]
        public static void AfterItemTypesDefined()
        {

            Managers.RecipeManager.BuildRecipeList();
            Managers.RecipeManager.ProcessRecipes();

        }


    }
}