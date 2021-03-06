﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;
using WebPx.Dependency;

namespace WebPx.Presentation
{
    public sealed class UnityResolver : IResolver
    {
        public static object GetInstance(Type objectType, object anonymousParameters)
        {
            ParameterOverrides parameters = null;
            if (anonymousParameters != null)
            {
                parameters = new ParameterOverrides();
                var apType = anonymousParameters.GetType();
                foreach (var parameter in apType.GetProperties())
                    parameters.Add(parameter.Name, parameter.GetValue(anonymousParameters));
            }
            return UnityResolution.Container.Resolve(objectType, parameters);
        }
        public static T GetInstance<T>(object anonymousParameters)
        {
            Type objectType = typeof(T);
            ParameterOverrides parameters = null;
            if (anonymousParameters != null)
            {
                parameters = new ParameterOverrides();
                foreach (var parameter in anonymousParameters.GetType().GetProperties())
                    parameters.Add(parameter.Name, parameter.GetValue(parameter));
            }
            return (T)UnityResolution.Container.Resolve(objectType, parameters);
        }

        internal static bool CanResolve(Type viewType)
        {
            return UnityResolution.Container.IsRegistered(viewType);
        }

        public T Resolve<T>()
        {
            return UnityResolution.Resolve<T>();
        }
    }
}
