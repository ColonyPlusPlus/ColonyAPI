using Pipliz.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Managers
{
    public static class TypeManager
    {

       // public static List<GrowableType> GrowableTypesTracker = new List<GrowableType>();

        public static List<string> AddedTypes = new List<string>();
        public static List<string> CreativeAddedTypes = new List<string>();
        public static List<Classes.Type> ActionTypeRegistry = new List<Classes.Type>();
        private static Dictionary<string, JSONNode> rawTypeDict = new Dictionary<string, JSONNode>();

        // using a prebuilt list of croptypes
        /*       public static void registerTrackedTypes()
               {
                   // loop through each growable type
                   foreach (GrowableType gt in GrowableTypesTracker)
                   {
                       // register each crop with our custom crop actions


                       ItemTypesServer.RegisterOnAdd(gt.TypeName, gt.OnAddAction);
                       ItemTypesServer.RegisterOnRemove(gt.TypeName, gt.OnRemoveAction);
                       ItemTypesServer.RegisterOnChange(gt.TypeName, gt.OnChangeAction);
                   }

                   Utilities.WriteLog("Registered Crop Actions");
               }
               */

        public static void registerRawType(string typename, JSONNode node)
        {
            if(rawTypeDict.ContainsKey(typename))
            {
                rawTypeDict[typename] = node;
            } else
            {
                rawTypeDict.Add(typename, node);
            }
        }

        public static void processTypeRegistration()
        {
            if(rawTypeDict.Count >0)
            {
                foreach(string typename in rawTypeDict.Keys)
                {
                    ItemTypes.AddRawType(typename, rawTypeDict[typename]);
                }
            }
        }

        public static void registerActionableTypes()
        {
            if (ActionTypeRegistry.Count > 0)
            {
                foreach (Classes.Type t in ActionTypeRegistry)
                {
                    t.RegisterActionCallback();
                }
            }

        }

        public static void registerActionableTypeCallback(Classes.Type t)
        {
            ActionTypeRegistry.Add(t);
        }



        // Register the crop in the growable Types list.
        /*public static void registerCrop(GrowableType classInstance)
        {
            GrowableTypesTracker.Add(classInstance);
        }*/
    }
}
