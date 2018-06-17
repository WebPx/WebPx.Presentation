using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class PresenterBuilder
    {
        public PresenterBuilder(PresenterBuilder parent = null)
        {
            _parent = parent;
        }

        private PresenterBuilder _parent;

        public PresenterBuilder Parent { get { return _parent; } set { _parent = value; } }

        public object Resolve(Type viewType, object view)
        {
            var result = TryResolve(viewType, view);
            if (result == null && _parent != null)
                result = _parent.Resolve(viewType, view);
            return result;
        }

        protected virtual object TryResolve(Type viewType, object view)
        {
            object presenter = null;
            var ci = Presenters.GetConstructor(viewType);
            if (ci != null)
            {
                var instance = ci.Invoke(new object[] { view });
                presenter = instance;
            }
            return presenter;
        }
    }
}
