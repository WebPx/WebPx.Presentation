using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    [Presenter]
    public abstract class Presenter<TView>
    {
        public Presenter(TView view)
        {
            this.View = view;
            this.AttachView(view);
            DoInitialize();
            InjectControllers();
        }

        protected internal Presenter(TView view, bool deferInitialization)
        {
            this.View = view;
            this.AttachView(view);
            if (deferInitialization)
                DoInitialize();
            InjectControllers();
            InjectModels();
        }

        private void InjectModels()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var isModel = false;
                var attributes = property.GetCustomAttributes<ModelAttribute>(true);
                if (attributes != null)
                    foreach (var attribute in attributes)
                        if (attribute != null)
                        {
                            isModel = true;
                            break;
                        }
                if (!isModel)
                {
                    attributes = propertyType.GetCustomAttributes<ModelAttribute>(true);
                    if (attributes != null)
                        foreach (var attribute in attributes)
                            if (attribute != null)
                            {
                                isModel = true;
                                break;
                            }
                }
                if (isModel)
                {
                    var constructor = propertyType.GetConstructor(Type.EmptyTypes);
                    if (constructor == null)
                        throw new PresentationResolverException("There is no public parameterless constructor in '{0}'", propertyType.FullName);
                    var instance = constructor.Invoke(null);
                    property.SetValue(this, instance);
                }
            }
        }

        private void InjectControllers()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var attributes = propertyType.GetCustomAttributes<ApplicationControllerAttribute>(true);
                if (attributes != null)
                    foreach (var attribute in attributes)
                        if (attribute != null)
                        {
                            var controller = Controllers.GetControllerFor(propertyType);
                            if (controller != null)
                            {
                                property.SetValue(this, controller);
                                Controllers.RaiseInjected(this, controller);
                            }
                            break;
                        }
            }
        }

        protected internal void DoInitialize()
        {
            if (this.View is IViewInitialize)
                ((IViewInitialize)this.View).Initialize();
        }

        public TView View { get; private set; }

        protected abstract void AttachView(TView view);

        private IPresenterData _data;

        public IPresenterData Data
        {
            get
            {
                return _data;
            }
        }
    }

    public abstract class Presenter<TModel, TView> : Presenter<TView>
        where TModel : class
    {
        public Presenter(TView view) : base(view, false)
        {
            this.Model = this.CreateModel();
            this.DoInitialize();
        }

        protected virtual TModel CreateModel()
        {
            var model = default(TModel);
            var modelType = typeof(TModel);
            var constructor = modelType.GetConstructor(Type.EmptyTypes);
            var instance = constructor.Invoke(null);
            model = (TModel)instance;
            return model;
        }

        public TModel Model { get; private set; }
    }
}
