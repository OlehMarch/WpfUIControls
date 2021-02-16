using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUIControls.API
{
    public struct WorldObjectModel
    {
        public WorldObjectModel(string label, string id, API.WorldObjectType type, API.WorldObjectRowHierarchyLevel hierarchyLevel)
        {
            Label = label;
            ID = id;
            Type = type;
            HierarchyLevel = hierarchyLevel;
        }

        public string Label { get; private set; }
        public string ID { get; private set; }
        public WorldObjectType Type { get; private set; }
        public WorldObjectRowHierarchyLevel HierarchyLevel { get; private set; }
    }
}
