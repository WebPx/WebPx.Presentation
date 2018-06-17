using System;
using System.Runtime.Serialization;

namespace WebPx.Web.Modules
{
    [Serializable]
    internal class ModuleCircularDependencyException : Exception
    {
        public ModuleCircularDependencyException()
        {
        }

        public ModuleCircularDependencyException(string message) : base(message)
        {
        }

        public ModuleCircularDependencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModuleCircularDependencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}