using ChatCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Managers
{ 
    public class MasterChatCommandManager : IChatCommand
    {
        public bool IsCommand(string chatItem) =>
            (Managers.ChatCommandManager.ChatCommandsList.ContainsKey(chatItem.Split(' ')[0]));

        public bool TryDoCommand(Players.Player ply, string chatItem)
        {
            Classes.BaseChatCommand command;
            ChatCommandManager.ChatCommandsList.TryGetValue(chatItem.Split(' ')[0], out command);
            Helpers.Utilities.WriteLog("ColonyAPI", chatItem + chatItem.Split(' ')[0]);
            if (command != null)
            {
                return command.TryDoCommand(ply, chatItem);
            }
            return false;
        }
    }
}
