using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ColonyAPI.Helpers
{
    public static class Utilities
    {
        // Write a log entry
        public static void WriteLog(string modname, string message)
        {
            Pipliz.Log.Write("[" + modname + "]: " + message);
        }

        public static void WriteLog(string modname, string message, Helpers.Chat.ChatColour color, Helpers.Chat.ChatStyle style)
        {
            Pipliz.Log.Write(Helpers.Chat.buildMessage("[" + modname + "]: " + message, color, style));
        }

        public static void WriteLogError(string modname, string message)
        {
            Pipliz.Log.WriteError("[" + modname + "]: " + message);
        }

        public static bool ValidateIcon(string exists)
        {
            string path = Directory.GetCurrentDirectory() + "/gamedata/textures/icons/" + exists + ".png";
            //WriteLog("ColonyAPI", "Type: " + exists + " result: " +path );
            return File.Exists(path);
        }

        public static void MakeDirectoriesIfNeeded(string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    }
}
