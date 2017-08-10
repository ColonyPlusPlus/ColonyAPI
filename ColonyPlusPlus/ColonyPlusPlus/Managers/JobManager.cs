using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Managers
{
    public static class JobManager
    {

        public static Dictionary<string, string> JobRecipeMappings = new Dictionary<string, string>();

        public static void RegisterJobType(string craftingtype, string jobIdentifier)
        {
            JobRecipeMappings.Add(craftingtype, jobIdentifier);
        }
    }
}
