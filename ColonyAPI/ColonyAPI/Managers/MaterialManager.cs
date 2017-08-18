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
            JSONNode j = new JSONNode(NodeType.Object)
               .SetAs("albedo", albedo)
               .SetAs("emissive", emissive)
               .SetAs("height", height)
               .SetAs("normal", normal);

            if (MatList.ContainsKey(identifier))
            {
                Helpers.Utilities.WriteLog("ColonyAPI", "[Warning] Material '" + identifier + "' already exists, replacing materials can have unexpected consequences.", Helpers.Chat.ChatColour.orange, Helpers.Chat.ChatStyle.normal);
                MatList[identifier] = j;
            } else
            {
                MatList.Add(identifier, j);
            }
        }
        private static string GetAlbedo(string modfolder, string file)
        {
            return "../../../../mods/" + modfolder + "/textures/materials/blocks/albedo/" + file;
        }
        private static string GetEmissive(string modfolder, string file)
        {
            return "../../../../mods/" + modfolder + "/textures/materials/blocks/emissiveMaskAlpha/" + file;
        }
        private static string GetHeight(string modfolder, string file)
        {
            return "../../../../mods/" + modfolder + "/textures/materials/blocks/heightSmoothnessSpecularity/" + file;
        }
        private static string GetNormal(string modfolder, string file)
        {
            return "../../../../mods/" + modfolder + "/textures/materials/blocks/normal/" + file;
        }

        public static bool ValidateMaterial(string id)
        {
            return MatList.ContainsKey(id);
        }

        public static void registerMaterials()
        {
            foreach (KeyValuePair<string, JSONNode> mat in MatList)
            {
                if (ItemTypesServer.ContainsTextureMapping(mat.Key))
                {
                    ItemTypesServer.RemoveTextureMapping(mat.Key);
                }
            }
         
        }
    }
}
