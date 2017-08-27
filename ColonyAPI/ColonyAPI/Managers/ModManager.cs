using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Managers
{
    public static class ModManager
    {
        public static Dictionary<string, Classes.Mod> ModList = new Dictionary<string, Classes.Mod>();

        public static void regsiterMod(string modName, Version modVersion)
        {
            Classes.Mod m = new Classes.Mod(modName, modVersion);
            ModList.Add(modName, m);
        }

        public static void regsiterMod(string modName, Version modVersion, string modFolder)
        {
            Classes.Mod m = new Classes.Mod(modName, modVersion, modFolder);
            ModList.Add(modName, m);
        }

        public static void regsiterMod(string modName, Version modVersion, string modFolder, string modUpdateURL)
        {
            Classes.Mod m = new Classes.Mod(modName, modVersion, modFolder, modUpdateURL);
            ModList.Add(modName, m);
        }

        public static Classes.Mod getMod(string name)
        {
            return ModList[name];
        }

        public static bool modInstalled(string name)
        {
            return ModList.ContainsKey(name);
        }

        public static void addDependency(string modname)
        {
            if(!ModList.ContainsKey(modname))
            {
                throw new Exceptions.ModNotInstalledException(modname + " not found in mod list");
            }
        }

    }
}
