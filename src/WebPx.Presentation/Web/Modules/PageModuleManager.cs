using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace WebPx.Web.Modules
{
    public class PageModuleManager
    {
        private PageModuleManager()
        {

        }

        internal class PageInfo
        {
            internal bool _stylesAdded = false;
            internal bool _controlsAdded = false;
            internal bool _scriptsRendered = false;
        }

        private const string _pmmKey = "webpx:PageModules";

        private Dictionary<string, ModuleStyle> _styles = new Dictionary<string, ModuleStyle>();
        private Dictionary<string, ModuleScript> _scripts = new Dictionary<string, ModuleScript>();
        private Dictionary<string, ModuleControl> _controls = new Dictionary<string, ModuleControl>();

        public ModuleStyle[] Styles { get { return _styles.Values.ToArray(); } }
        public ModuleScript[] Scripts { get { return _scripts.Values.ToArray(); } }
        public ModuleControl[] Controls { get { return _controls.Values.ToArray(); } }

        public bool HasStyles => _styles.Count > 0;
        public bool HasScripts => _scripts.Count > 0;
        public bool HasControls => _controls.Count > 0;

        internal static PageInfo Get(System.Web.UI.Control control)
        {
            //control.Page.Request.RequestContext.HttpContext.Items;
            var items = control.Page.Items;
            lock (items)
            {
                var instance = items[_pmmKey] as PageInfo;
                if (instance == null)
                {
                    instance = new PageInfo();
                    items[_pmmKey] = instance;
                }
                return instance;
            }
        }

        public static PageModuleManager Instance
        {
            get
            {
                if (_singleton == null)
                {
                    var temp = new PageModuleManager();
                    temp.Load();
                    _singleton = temp;
                }
                return _singleton;
            }
        }

        private void Load()
        {
            var directory = HostingEnvironment.VirtualPathProvider.GetDirectory("~/__layout/Components");
            if (directory != null)
            {
                var files = directory.Files;
                foreach (VirtualFile file in files)
                    switch (Path.GetExtension(file.Name).ToLower())
                    {
                        case ".webmodule":
                            LoadDefinition(file.VirtualPath);
                            break;
                    }
            }
        }

        private static List<string> temporaryList = new List<string>();

        private void LoadDefinition(string virtualPath)
        {
            try
            {
                if (temporaryList.Contains(virtualPath))
                    throw new ModuleCircularDependencyException(string.Format("Found a Circular Reference to the webmodule {0}", virtualPath));
                temporaryList.Add(virtualPath);
                if (_controls.ContainsKey(virtualPath))
                    return;
                var directFile = HostingEnvironment.VirtualPathProvider.GetFile(virtualPath);
                using (var fileStream = directFile.Open())
                {
                    var module = ModuleDefinition.FromStream(fileStream);
                    foreach (var dependency in module.Dependencies)
                        if (!string.IsNullOrEmpty(dependency.Path))
                            LoadDefinition(JoinPath(virtualPath, dependency.Path));
                    foreach (var script in module.Scripts)
                        if (!this._scripts.ContainsKey(script.Path))
                            this._scripts.Add(script.Path, script);
                    foreach (var style in module.Styles)
                        if (!this._styles.ContainsKey(style.Path))
                            this._styles.Add(style.Path, style);
                    foreach (var control in module.Controls)
                        if (!this._controls.ContainsKey(control.Path))
                            this._controls.Add(control.Path, control);
                    //_sources.Add(virtualPath, module.Source);
                }
            }
            finally
            {
                temporaryList.Remove(virtualPath);
            }
        }

        private string JoinPath(string virtualPath, string relativePath)
        {
            if (relativePath.StartsWith("~/") || relativePath.StartsWith("/"))
                return relativePath;
            var parts = new Stack<string>();
            var urlparts = virtualPath.Split(new char[] { '/' },StringSplitOptions.RemoveEmptyEntries);

            var newParts = new string[urlparts.Length - 1];
            Array.Copy(urlparts, 0, newParts, 0, newParts.Length);
            urlparts = newParts;

            foreach (var urlpart in urlparts)
                parts.Push(urlpart);
            foreach (var urlpart in relativePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
                switch (urlpart)
                {
                    case "..": parts.Pop(); break;
                    default: parts.Push(urlpart); break;
                }
            var reversed = new List<string>(parts.Reverse());
            var newPath = string.Format("/{0}", string.Join("/", reversed));
            return newPath;
        }

        private static PageModuleManager _singleton;
    }
}
