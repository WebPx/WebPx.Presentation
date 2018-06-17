using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public static class Controllers
    {
        private static Dictionary<Type, ControllerInfo> _controllerTypes = new Dictionary<Type, ControllerInfo>();

        public static void Add<TContract, TController>() where TController : class, TContract
        {
            var contractType = typeof(TContract);
            var controllerType = typeof(TController);
            InternalAdd(contractType, controllerType);
        }

        public static void Add(Type contractType, Type controllerType)
        {
            InternalAdd(contractType, controllerType);
        }

        private static ControllerInfo InternalAdd(Type contractType, Type controllerType)
        {
            var constructor = controllerType.GetConstructor(Type.EmptyTypes);
            if (constructor == null)
                throw new PresentationResolverException("There is no public parameterless constructor in '{0}'", controllerType.FullName);
            var controller = constructor.Invoke(null);
            var temp = new ControllerInfo();
            temp.Type = controllerType;
            temp.Constructor = constructor;
            temp.Instance = controller;
            _controllerTypes.Add(contractType, temp);
            return temp;
        }

        public static object GetControllerFor<TContract>()
        {
            var viewType = typeof(TContract);
            var result = Controllers.GetControllerFor(viewType);
            return result;
        }

        public static event ResolveControllerEventHandler ResolveController;

        public static object GetControllerFor(Type contractType)
        {
            object presenter = null;
            ControllerInfo pi = null;
            if (_controllerTypes.ContainsKey(contractType))
                pi = _controllerTypes[contractType];
            if (pi == null)
            {
                var args = new ResolveControllerEventArgs(contractType);
                Type presenterType = null;
                if (ResolveController != null)
                    foreach (var resolver in ResolveController.GetInvocationList())
                    {
                        ((ResolveControllerEventHandler)resolver).Invoke(null, args);
                        if (args.ControllerType != null)
                        {
                            presenterType = args.ControllerType;
                            break;
                        }
                    }
                if (presenterType != null)
                    pi = InternalAdd(contractType, presenterType);
            }
            if (pi != null)
                presenter = pi.Instance;
            return presenter;
        }

        public static event ControllerInjectedEventHandler ControllerInjected;

        class ControllerInfo
        {
            public ControllerInfo()
            {

            }

            public Type Type { get; set; }

            public ConstructorInfo Constructor { get; set; }

            public Expression Expression { get; set; }

            public object Instance { get; set; }
        }

        internal static void RaiseInjected(object sender, object controller)
        {
            if (ControllerInjected != null)
                ControllerInjected(sender, new ControllerInjectedEventArgs(controller));
        }
    }
}
