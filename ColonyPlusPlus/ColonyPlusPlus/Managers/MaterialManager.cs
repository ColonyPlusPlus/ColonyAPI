using Pipliz.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Managers
{
    public static class MaterialManager
    {
        private static Dictionary<string, JSONNode> MatList = new Dictionary<string, JSONNode>();
        /// <summary>
        /// Pretty self explanatory
        /// </summary>
        /// <param name="identifier">The name of the material (eg: "testmaterial")</param>
        /// <param name="albedo"></param>
        /// <param name="emissive"></param>
        /// <param name="height"></param>
        /// <param name="normal"></param>
        public static void createMaterial(string identifier, string albedo, string emissive, string height, string normal)
        {
            // Register it with the ItemTypesServer
            JSONNode j = new JSONNode(NodeType.Object)
                .SetAs("albedo", albedo)
                .SetAs("emissive", emissive)
                .SetAs("height", height)
                .SetAs("normal", normal)
            );
            MatList.Add(identifier, j);
        }

        public static bool ValidateMaterial(string id)
        {
            return MatList.ContainsKey(id);
        }

        public static void registerMaterials()
        {
            foreach (KeyValuePair<string, JSONNode> mat in MatList)
            {
                ItemTypesServer.AddTextureMapping(mat.Key, mat.Value);
            }
        }
    }
}
