using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebPx.Web.Modules
{
    [Serializable]
    public sealed class ModuleScript
    {
        public ModuleScript()
        {

        }

        [XmlAttribute]
        public string Path { get; set; }
    }
}
