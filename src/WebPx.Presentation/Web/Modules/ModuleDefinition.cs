using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebPx.Web.Modules
{
    [Serializable]
    [XmlRoot("Module", Namespace = "http://schemas.webpx.com/presentation/modules/v1")]
    public sealed class ModuleDefinition
    {
        public ModuleDefinition()
        {

        }

        [XmlAttribute]
        public string Name { get; set; }

        private ModuleControlCollection _controls;

        [XmlArrayItem("Control")]
        public ModuleControlCollection Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }

        private ModuleStyleCollection _styles;

        [XmlArrayItem("Style")]
        public ModuleStyleCollection Styles
        {
            get
            {
                if (_styles == null)
                    _styles = new ModuleStyleCollection();
                return _styles;
            }
        }

        private ModuleScriptCollection _scripts;

        [XmlArrayItem("Script")]
        public ModuleScriptCollection Scripts
        {
            get
            {
                if (_scripts == null)
                    _scripts = new ModuleScriptCollection();
                return _scripts;
            }
        }

        private ModuleDependencyCollection _dependencies;

        [XmlArrayItem("Dependency")]
        public ModuleDependencyCollection Dependencies
        {
            get
            {
                if (_dependencies == null)
                    _dependencies = new ModuleDependencyCollection();
                return _dependencies;
            }
        }

        public static ModuleDefinition FromPath(string path)
        {
            var serializer = new XmlSerializer(typeof(ModuleDefinition));
            using (var reader = File.OpenRead(path))
            {
                return (ModuleDefinition)serializer.Deserialize(reader);
            }
        }

        public static ModuleDefinition FromStream(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(ModuleDefinition));
            return (ModuleDefinition)serializer.Deserialize(stream);
        }

        public static void ToStream(Stream stream, ModuleDefinition definition)
        {
            var serializer = new XmlSerializer(typeof(ModuleDefinition));
            serializer.Serialize(stream, definition);
        }

        public static string ToString(ModuleDefinition definition)
        {
            var serializer = new XmlSerializer(typeof(ModuleDefinition));
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
                serializer.Serialize(sw, definition);
            return sb.ToString();
        }
    }
}
