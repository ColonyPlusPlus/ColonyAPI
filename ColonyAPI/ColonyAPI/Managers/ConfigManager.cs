using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pipliz.JSON;

namespace ColonyAPI.Managers
{
    public static class ConfigManager
    {

        private static Dictionary<string, JSONNode> configSettings = new Dictionary<string, JSONNode>();

        public static void registerConfig(string modname, string configname = "config.json")
        {
            if(!configSettings.ContainsKey(modname))
            {
                JSONNode configNode = new JSONNode(NodeType.Object);
                try
                {
                    Pipliz.JSON.JSON.Deserialize(getConfigLocation(modname), out configNode, true);
                }
                catch (Exception exception2)
                {
                    Helpers.Utilities.WriteLog("ColonyAPI", "Error loading configuration (" + modname + "):" + exception2.Message + exception2.StackTrace);
                }

                configSettings.Add(modname, configNode);
                Helpers.Utilities.WriteLog("ColonyAPI", "Loaded configuration (" + modname + ")");
            }
        }

        private static JSONNode getConfigDataNode(string modname)
        {
            if(configSettings.ContainsKey(modname))
            {
                return configSettings[modname];

            } else
            {
                return new JSONNode(NodeType.Object);
            }
        }


        public static string getConfigString(string modname, string key)
        {
            JSONNode configNode = getConfigDataNode(modname);

            string[] keys = key.Split('.');

            if (keys.Length > 0)
            {
                return getConfigStringFromNode(keys, 0, configNode, modname);
            }
            else
            {
                return configNode.GetAs<string>(key);
            }
        }

        private static string getConfigStringFromNode(string[] keys, int keyIndex, JSONNode node, string modname)
        {
            try
            {
                if (keys.Length > 0 && keyIndex < keys.Length - 1)
                {
                    if (node.HasChild(keys[keyIndex]))
                    {
                        // has child
                        JSONNode c = new JSONNode(NodeType.Object);
                        c = node.GetAs<JSONNode>(keys[keyIndex]);
                        return getConfigStringFromNode(keys, keyIndex + 1, c, modname);

                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return node.GetAs<string>(keys[keyIndex]);
                }
            }
            catch (Exception exception)
            {
                Helpers.Utilities.WriteLog("ColonyAPI", "Error loading configuration (" + modname + "):" + keys.Length.ToString() + keyIndex.ToString() + exception.Message + exception.StackTrace);
                return "";
            }

        }

        public static bool getConfigBoolean(string modname, string key)
        {
            JSONNode configNode = getConfigDataNode(modname);

            string[] keys = key.Split('.');

            if (keys.Length > 0)
            {
                return getConfigBoolFromNode(keys, 0, configNode, modname);
            }
            else
            {
                return configNode.GetAs<bool>(key);
            }
        }

        private static bool getConfigBoolFromNode(string[] keys, int keyIndex, JSONNode node, string modname)
        {
            try
            {
                if (keys.Length > 0 && keyIndex < keys.Length - 1)
                {
                    if (node.HasChild(keys[keyIndex]))
                    {
                        // has child
                        JSONNode c = new JSONNode(NodeType.Object);
                        c = node.GetAs<JSONNode>(keys[keyIndex]);
                        return getConfigBoolFromNode(keys, keyIndex + 1, c, modname);

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return node.GetAs<bool>(keys[keyIndex]);
                }
            }
            catch (Exception exception)
            {
                Helpers.Utilities.WriteLog("ColonyAPI", "Error loading configuration (" + modname + "):" + keys[0] + keys.Length.ToString() + keyIndex.ToString() + exception.Message + exception.StackTrace);
                return false;
            }

        }

        public static int getConfigInt(string modname, string key)
        {
            JSONNode configNode = getConfigDataNode(modname);

            string[] keys = key.Split('.');

            if (keys.Length > 0)
            {
                return getConfigIntFromNode(keys, 0, configNode, modname);
            }
            else
            {
                return configNode.GetAs<int>(key);
            }
        }

        private static int getConfigIntFromNode(string[] keys, int keyIndex, JSONNode node, string modname)
        {
            try
            {
                if (keys.Length > 0 && keyIndex < keys.Length - 1)
                {
                    if (node.HasChild(keys[keyIndex]))
                    {
                        // has child
                        JSONNode c = new JSONNode(NodeType.Object);
                        c = node.GetAs<JSONNode>(keys[keyIndex]);
                        return getConfigIntFromNode(keys, keyIndex + 1, c, modname);

                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return node.GetAs<int>(keys[keyIndex]);
                }
            }
            catch (Exception exception)
            {
                Helpers.Utilities.WriteLog("ColonyAPI", "Error loading configuration (" + modname + "):" + keys.Length.ToString() + keyIndex.ToString() + exception.Message + exception.StackTrace);
                return -1;
            }

        }

        public static float getConfigFloat(string modname, string key)
        {
            JSONNode configNode = getConfigDataNode(modname);

            string[] keys = key.Split('.');

            if (keys.Length > 0)
            {
                return getConfigFloatFromNode(keys, 0, configNode, modname);
            }
            else
            {
                return configNode.GetAs<float>(key);
            }
        }

        private static float getConfigFloatFromNode(string[] keys, int keyIndex, JSONNode node, string modname)
        {
            try
            {
                if (keys.Length > 0 && keyIndex < keys.Length - 1)
                {
                    if (node.HasChild(keys[keyIndex]))
                    {
                        // has child
                        JSONNode c = new JSONNode(NodeType.Object);
                        c = node.GetAs<JSONNode>(keys[keyIndex]);
                        return getConfigFloatFromNode(keys, keyIndex + 1, c, modname);

                    }
                    else
                    {
                        return 0f;
                    }
                }
                else
                {
                    return node.GetAs<float>(keys[keyIndex]);
                }
            }
            catch (Exception exception)
            {
                Helpers.Utilities.WriteLog("ColonyAPI", "Error loading configuration (" + modname + "):" + keys.Length.ToString() + keyIndex.ToString() + exception.Message + exception.Message);
                return 0f;
            }

        }

        public static JSONNode getConfigNode(string modname, string key)
        {
            JSONNode configNode = getConfigDataNode(modname);

            string[] keys = key.Split('.');

            if (keys.Length > 0)
            {
                return getConfigNodeFromNode(keys, 0, configNode, modname);
            }
            else
            {
                return configNode.GetAs<JSONNode>(key);
            }
        }

        private static JSONNode getConfigNodeFromNode(string[] keys, int keyIndex, JSONNode node, string modname)
        {
            try
            {
                if (keys.Length > 0 && keyIndex < keys.Length - 1)
                {
                    if (node.HasChild(keys[keyIndex]))
                    {
                        // has child
                        JSONNode c = new JSONNode(NodeType.Object);
                        c = node.GetAs<JSONNode>(keys[keyIndex]);
                        return getConfigNodeFromNode(keys, keyIndex + 1, c, modname);

                    }
                    else
                    {
                        return new JSONNode(NodeType.Array);
                    }
                }
                else
                {
                    return node.GetAs<JSONNode>(keys[keyIndex]);
                }
            }
            catch (Exception exception)
            {
                Helpers.Utilities.WriteLog("ColonyAPI", "Error loading configuration (" + modname + "):" + keys.Length.ToString() + keyIndex.ToString() + exception.Message + exception.StackTrace);
                return new JSONNode(NodeType.Array);
            }

        }

        /// <summary>
        /// Get the config location
        /// </summary>
        /// <returns></returns>
        private static string getConfigLocation(string modname)
        {
            return "gamedata/mods/"+modname+"/config.json";
        }
    }
}
