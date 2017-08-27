using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pipliz.JSON;

namespace ColonyAPI.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataManager
    {
        private static JSONNode dataObj = new JSONNode(NodeType.Object);
       
        /// <summary>
        /// Check if the data manager contains a node
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool hasNode(string name)
        {
            return dataObj.HasChild(name);
        }

        /// <summary>
        /// Get a JSONNode from the datamanager by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static JSONNode getNode(string name)
        {
            if(hasNode(name))
            {
                return dataObj.GetAs<JSONNode>(name);
            } else
            {
                return new JSONNode(NodeType.Object);
            }
        }

        /// <summary>
        /// Set the contents of a JSON node from the data manager
        /// </summary>
        /// <param name="name"></param>
        /// <param name="node"></param>
        public static void setNode(string name, JSONNode node)
        {
            dataObj.SetAs<JSONNode>(name, node);
        }

        /// <summary>
        /// Register a node with the data manager - creating it if it doesn't exist already
        /// </summary>
        /// <param name="name"></param>
        public static void registerNode(string name)
        {

        }

        /// <summary>
        /// Load data from the savegame directory to the data manager
        /// </summary>
        private static void loadData()
        {

        }

        /// <summary>
        /// Save data from the data manager to the savegame directory
        /// </summary>
        private static void saveData()
        {

        }
    }
}
