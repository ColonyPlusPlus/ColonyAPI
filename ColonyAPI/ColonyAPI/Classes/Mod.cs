using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Classes
{
    public class Mod
    {
        public Version version;
        public string modFolder;
        public string updateURL;
        public bool hasUpdateURL;

        public Mod(string name, Version v)
        {
            version = v;
            modFolder = name;
        }

        public Mod(string name, Version v, string folder)
        {
            version = v;
            modFolder = folder;
        }

        public Mod(string name, Version v, string folder, string upurl)
        {
            version = v;
            modFolder = folder;
            updateURL = upurl;
            hasUpdateURL = true;
        }
        

    }
}
