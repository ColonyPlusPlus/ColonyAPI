using Pipliz.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            rawTypeDict[typename] = node;
            
        }

        public static void processTypeRegistration()
        {
            List<string> CurrentRawTypes = ItemTypes.GetAllRawTypes();
            Helpers.Utilities.WriteLog("ColonyAPI", "Base Type Count: " + CurrentRawTypes.Count);

            if (rawTypeDict.Count >0)
            {
                foreach(string typename in rawTypeDict.Keys)
                {
                    if(CurrentRawTypes.Contains(typename))
                    {
                        Helpers.Utilities.WriteLog("ColonyAPI", "Found duplicate type: " + typename);
                        ItemTypes.RemoveRawType(typename);
                    }
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

        public static void autoDiscoverTypes()
        {
            int typeCount = 0;
            var typeInterface = typeof(Interfaces.IAutoType);
            //var typelist = Assembly.GetExecutingAssembly().GetTypes().Where(t => (t != null && t.IsClass && !t.IsAbstract && typeInterface.IsAssignableFrom(t)));
            var typelist = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(t => (t.IsClass && typeInterface.IsAssignableFrom(t)));
            foreach (var t in typelist)
            {
                try
                {
                    Helpers.Utilities.WriteLog("ColonyAPI", t.Name + " Found. Registering.");
                    Classes.Type type = ((Classes.Type)Activator.CreateInstance(t));
                    type.Register();

                    typeCount += 1;
                }
                catch (MissingMethodException mme)
                {
                    Helpers.Utilities.WriteLog("ColonyAPI", t.Name + " cannot be instantiated. This probably isn't an error.");
                    Pipliz.Log.WriteWarning(mme.Message);
                }
                catch (InvalidCastException ice)
                {
                    Helpers.Utilities.WriteLog("ColonyAPI", t.Name + " doesn't properly implement our Type system. This probably isn't an error.");
                    Pipliz.Log.WriteWarning(ice.Message);
                }
                catch (Exception e)
                {
                    Helpers.Utilities.WriteLog("ColonyAPI", t.Name + " Type Error.");
                    Pipliz.Log.WriteWarning(e.Message + e.StackTrace);
                }
            }
            Helpers.Utilities.WriteLog("ColonyAPI", typeCount + " Types Autoloaded.");
        }


        // Register the crop in the growable Types list.
        /*public static void registerCrop(GrowableType classInstance)
        {
            GrowableTypesTracker.Add(classInstance);
        }*/
    }
}
