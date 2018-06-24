using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace WebPx.Presentation
{
    public static class UnityResolution
    {
        private static UnityContainer _unityContainer;

        internal static UnityContainer Container
        {
            get
            {
                if (_unityContainer == null)
                    _unityContainer = new UnityContainer();
                return _unityContainer;
            }
        }

        public static void RegisterType<TContract, TService>()
            where TService: class, TContract
        {
            Container.RegisterType<TContract, TService>();
        }
    }
}
