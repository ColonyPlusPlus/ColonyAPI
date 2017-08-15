using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace ColonyAPI.Managers
{
    public static class ChatCommandManager
    {
        public static Dictionary<string, ColonyAPI.Classes.BaseChatCommand> ChatCommandsList = new Dictionary<string, ColonyAPI.Classes.BaseChatCommand>();

        public static void Initialize()
        {
            var typeInterface = typeof(Interfaces.IAutoChatCommand);
           
            var typelist = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(t => (t.IsClass && typeInterface.IsAssignableFrom(t)));
            foreach (var t in typelist)
            {
                try
                {
                    ColonyAPI.Classes.BaseChatCommand command = ((ColonyAPI.Classes.BaseChatCommand)Activator.CreateInstance(t));
                    ChatCommandsList.Add(command.ChatCommandPrefix, command);
                    ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPI", "Registered chat command: " + command.ChatCommandPrefix);
                }
                catch (MissingMethodException mme)
                {
                    ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPI", t.Name + " cannot be instantiated. This probably isn't an error.");
                    Pipliz.Log.WriteWarning(mme.Message);
                }
                catch (InvalidCastException ice)
                {
                    ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPI", t.Name + " doesn't use our command system. This probably isn't an error.");
                    Pipliz.Log.WriteWarning(ice.Message);
                }
                catch (Exception e)
                {
                    ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPI", t.Name + " Command Error.");
                    Pipliz.Log.WriteWarning(e.Message + e.StackTrace);
                }
            }
            ColonyAPI.Helpers.Utilities.WriteLog("ColonyAPI", "Chat Commands Loaded.");
        }
    }
}
