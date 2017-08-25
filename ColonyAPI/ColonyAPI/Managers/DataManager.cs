using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pipliz.JSON;

namespace ColonyAPI.Managers
{
    public static class DataManager
    {
        private static JSONNode dataObj = new JSONNode(NodeType.Object);
       
        public static bool hasNode(string name)
        {
            return dataObj.HasChild(name);
        }

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

        public static void setNode(string name, JSONNode node)
        {
            dataObj.SetAs<JSONNode>(name, node);
        }
    }
}
