using System;
using System.Xml.Serialization;

namespace WebPx.Web.Modules
{
    [Serializable]
    public class ModuleControl
    {
        public ModuleControl()
        {

        }

        [XmlAttribute]
        public ModuleControlType Type { get; set; }

        [XmlAttribute]
        public string Path { get; set; }

        [XmlAttribute]
        public string ClassType { get; set; }

        [XmlAttribute]
        public int Priority { get; set; }
    }
}