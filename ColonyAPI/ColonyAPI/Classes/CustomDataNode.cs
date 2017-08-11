using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Classes
{
    public class CustomDataNode
    {
        public Pipliz.JSON.JSONNode customDataNode = new Pipliz.JSON.JSONNode(Pipliz.JSON.NodeType.Object);

        /// <summary>
        /// Constructor for string nodes ("name":"value")
        /// </summary>
        /// <param name="name">Node Name</param>
        /// <param name="value">Node Value (string)</param>
        public CustomDataNode(string name, string value)
        {
            customDataNode.SetAs(name, value);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ColonyPlusPlus.classes.CustomDataHelper"/> class with child nodes
        /// </summary>
        /// <param name="childnodes">Childnodes.</param>
        public CustomDataNode(CustomDataItem[] childnodes)
        {
            foreach (CustomDataItem c in childnodes)
            {
                customDataNode = c.getCustomData(customDataNode);
            }
        }

        // NOT YET IMPLEMENTED
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ColonyPlusPlus.classes.CustomDataHelper"/> class with child nodes
        /// </summary>
        /// <param name="name">The name to give the node</param>
        /// <param name="childnodes">Childnodes.</param>
        /// <param name="node">The referenced parent node</param>
        public CustomDataNode(string name, CustomDataItem[] childnodes, Pipliz.JSON.JSONNode node)
        {
            Pipliz.JSON.JSONNode customChildNode = new Pipliz.JSON.JSONNode(Pipliz.JSON.NodeType.Object);
            foreach (CustomDataItem c in childnodes)
            {
                customChildNode = c.getCustomData(customChildNode);
            }

            node.SetAs(name, customChildNode);
            customDataNode = node;
        }

        // blah = new CustomDataHelper("itemname", "someitem");
        // blah = new CustomDataHelper({ new CustomDataItem("childname", "childvalue"), new CustomDataItem("childname2", true) });

    }


}
