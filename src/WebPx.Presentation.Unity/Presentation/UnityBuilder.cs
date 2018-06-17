using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;
using Unity.Resolution;

namespace WebPx.Presentation
{
    class UnityBuilder : PresenterBuilder
    {
        public UnityBuilder()
        {

        }

        protected override object TryResolve(Type presenterType, object view)
        {
            return UnityResolver.GetInstance(presenterType, new { view = view });
            //ParameterOverrides parameters = null;
            //if (view != null)
            //{
            //    parameters = new ParameterOverrides();
            //    parameters.Add("view", view);
            //}
            //return UnityConfig.Container.Resolve(presenterType, parameters);
        }
    }
}
