using Pipliz.Chatting;
using static Players;
using System;
using System.Collections.Generic;

namespace ColonyAPI
{
    [ModLoader.ModManager]
    public class ColonyAPIBase
    {

        public static Version APIVersion = new Version(0, 1, 2);

		// Initialise things for the modloader, ideally nothing would run before this!
		[ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, "colonyapi.initialise")]
		public static void AfterStartup()
		{
			Helpers.Utilities.WriteLog("ColonyAPI", "Initialising ColonyAPI v" + APIVersion.ToString(3), Helpers.Chat.ChatColour.cyan, Helpers.Chat.ChatStyle.bold);

			Helpers.ServerVariableParser.init();

            // A temporary fix
			Temporary.BaseGameMaterialManager.initialiseMaterials();

		}

		// Discover all commands, add them to a list
		[ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, "colonyapi.discoverCommands")]
		public static void DiscoverCommands()
		{
			// Initialize chat commands
			Managers.ChatCommandManager.Initialize();

		}

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerConnectedLate, "colonyapi.OnPlayerConnectedLate")]
        public static void OnPlayerConnectedLate(Player p)
        {
            
        }

        // run material registration, to register materials, you can ProvidesFor("colonyapi.registerMaterials")
		[ModLoader.ModCallback(ModLoader.EModCallbackType.AfterAddingBaseTypes, "colonyapi.registerMaterials")]
        [ModLoader.ModCallbackProvidesFor("colonyapi.discoverTypes")]
        public static void AfterAddingBaseTypesMaterials()
		{
			Helpers.Utilities.WriteLog("ColonyAPI", "Starting Material Registration");

			Managers.MaterialManager.registerMaterials();

			Helpers.Utilities.WriteLog("ColonyAPI", "Ending Material Registration");
		}

        // Autodiscover all types that implement IAutoType, unlikely someone would need to hook into this
		[ModLoader.ModCallback(ModLoader.EModCallbackType.AfterAddingBaseTypes, "colonyapi.discoverTypes")]
        [ModLoader.ModCallbackProvidesFor("colonyapi.registerTypes")]
        public static void AfterAddingBaseTypesDiscover()
		{
			Helpers.Utilities.WriteLog("ColonyAPI", "Starting Type Discovery");

			Managers.TypeManager.autoDiscoverTypes();

			Helpers.Utilities.WriteLog("ColonyAPI", "Ending Type Discovery");
		}

        // Register any autodiscovered types. This would be the LAST chance to add something to the type list before registration
		[ModLoader.ModCallback(ModLoader.EModCallbackType.AfterAddingBaseTypes, "colonyapi.registerTypes")]
		public static void AfterAddingBaseTypesProcess()
		{
			Helpers.Utilities.WriteLog("ColonyAPI", "Starting Type Registration");

			Managers.TypeManager.processTypeRegistration();

			Helpers.Utilities.WriteLog("ColonyAPI", "Ending Type Registration");
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

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterDefiningNPCTypes, "colonyapi.AddRecipeTypes")]
        [ModLoader.ModCallbackProvidesFor("colonyapi.AfterDefiningNPCTypes")]
        public static void DefineRecipeMappings()
        {
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterItemTypesDefined, "colonyapi.AfterItemTypesDefined")]
        [ModLoader.ModCallbackDependsOn("pipliz.blocknpcs.loadrecipes")]
        [ModLoader.ModCallbackProvidesFor("pipliz.apiprovider.registerrecipes")]
        public static void AfterItemTypesDefined()
        {
            Managers.RecipeManager.registerBaseRecipeBindings();
            Managers.RecipeManager.BuildRecipeList();
            Managers.RecipeManager.ProcessRecipes();

        }


    }
}