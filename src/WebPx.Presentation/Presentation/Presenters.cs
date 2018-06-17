using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public static class Presenters
    {
        private static Dictionary<Type, PresenterInfo> _viewTypes = new Dictionary<Type,PresenterInfo>();

        public static void Add<TView, TPresenter>() where TPresenter : class
        {
            var viewType = typeof(TView);
            var presenterType = typeof(TPresenter);
            InternalAdd(viewType, presenterType);
        }

        public static void AddResolver(PresenterBuilder presenterResolver)
        {
            if (presenterResolver == null)
                throw new ArgumentNullException(nameof(presenterResolver));
            presenterResolver.Parent = _presenterResolver;
            _presenterResolver = presenterResolver;
        }

        static PresenterBuilder _presenterResolver = new PresenterBuilder();

        public static void Add(Type viewType, Type presenterType)
        {
            InternalAdd(viewType, presenterType);
        }

        private static PresenterInfo InternalAdd(Type viewType, Type presenterType)
        {
            var constructor = presenterType.GetConstructor(new Type[] { viewType });
            if (constructor == null)
                throw new PresentationResolverException("There is no public constructor in '{0}' with an argument for the requested view type '{1}'", presenterType.FullName, viewType.FullName);
            var temp = new PresenterInfo();
            temp.Type = presenterType;
            temp.Constructor = constructor;
            _viewTypes.Add(viewType, temp);
            return temp;
        }

        public static object GetPresenterFor<TView>(TView view)
        {
            var viewType = typeof(TView);
            var result = Presenters.GetPresenterFor(viewType, view);
            return result;
        }

        public static event ResolvePresenterEventHandler ResolvePresenter;

        public static PresenterBuilder PresenterResolver
        {
            get
            {
                return _presenterResolver;
            }
        }

        public static object GetPresenterFor(Type viewType, object view)
        {
            if (view == null)
                throw new ArgumentNullException("value");
            if (!viewType.IsAssignableFrom(view.GetType()))
                throw new ArgumentException(string.Format("The provided view is not of the type '{0}'", viewType.FullName), "view");
            var presenterType = GetPresenterType(viewType);
            object presenter = PresenterResolver.Resolve(presenterType, view);
            //object presenter = null;
            //ConstructorInfo ci = GetConstructor(viewType);
            //if (ci!=null)
            //{
            //    var instance = ci.Invoke(new object[] { view });
            //    presenter = instance;
            //}
            return presenter;
        }

        internal static ConstructorInfo GetConstructor(Type viewType)
        {
            ConstructorInfo ci = null;
            PresenterInfo pi = null;
            if (_viewTypes.ContainsKey(viewType))
                pi = _viewTypes[viewType];
            if (pi == null)
            {
                var args = new ResolvePresenterEventArgs(viewType);
                Type presenterType = null;
                if (ResolvePresenter != null)
                    foreach (var resolver in ResolvePresenter.GetInvocationList())
                    {
                        ((ResolvePresenterEventHandler)resolver).Invoke(null, args);
                        if (args.PresenterType != null)
                        {
                            presenterType = args.PresenterType;
                            break;
                        }
                    }
                if (presenterType != null)
                    pi = InternalAdd(viewType, presenterType);
            }
            if (pi != null)
                ci = pi.Constructor;
            return ci;
        }

        private static Type GetPresenterType(Type viewType)
        {
            Type presenterType = null;
            if (_viewTypes.ContainsKey(viewType))
                presenterType = _viewTypes[viewType].Type;
            return presenterType;
        }

        class PresenterInfo
        {
            public PresenterInfo()
            {

            }

            public Type Type { get; set; }

            public ConstructorInfo Constructor { get; set; }

            public Expression Expression { get; set; }
        }
    }
}
