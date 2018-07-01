using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.UI;
using WebPx.Presentation;

namespace WebPx.Web.Compilation
{
    public sealed class PresenterInterceptor : ControlBuilderInterceptor
    {
        public PresenterInterceptor()
        {

        }

        public override void PreControlBuilderInit(
            ControlBuilder controlBuilder, 
            TemplateParser parser, 
            ControlBuilder parentBuilder, 
            Type type, 
            string tagName, 
            string id, 
            IDictionary attributes, 
            IDictionary additionalState)
        {
            base.PreControlBuilderInit(controlBuilder, parser, parentBuilder, type, tagName, id, attributes, additionalState);
            if (type != null)
            {
                var interfaces = type.FindInterfaces((checkType, fc) =>
                {
                    var atts = checkType.GetCustomAttributes(typeof(ViewAttribute), true);
                    return typeof(IView).IsAssignableFrom(checkType) || atts.Length > 0;
                }, null);
                if (interfaces!=null && interfaces.Length > 0)
                {
                    var viewInterfaces = interfaces.Except(new[] { typeof(IView) }).Where(Presenters.HasPresenter);
                    //foreach (var viewInterface in )
                    //    try
                    //    {
                            additionalState.Add("Presenter Constructor", viewInterfaces.ToArray());
                            //var constructor = Presenters.GetConstructor(viewInterface);
                            //if (constructor!=null)
                            //    additionalState.Add("Presenter Constructor", constructor);
                            //else
                            //{
                            //    System.CodeDom.CodeMethodInvokeExpression resolver = Presenters.GetResolver(viewInterface);
                            //}
                        //}
                        //catch
                        //{

                        //}
                }
            }
        }

        public override void OnProcessGeneratedCode(
            ControlBuilder controlBuilder, 
            CodeCompileUnit codeCompileUnit, 
            CodeTypeDeclaration baseType, 
            CodeTypeDeclaration derivedType, 
            CodeMemberMethod buildMethod, 
            CodeMemberMethod dataBindingMethod, 
            IDictionary additionalState)
        {
            base.OnProcessGeneratedCode(controlBuilder, codeCompileUnit, baseType, derivedType, buildMethod, dataBindingMethod, additionalState);
            if (additionalState.Contains("Presenter Constructor"))
            {
                var views = additionalState["Presenter Constructor"];
                //if (resolver is ConstructorInfo)
                //{
                //    var presenterConstructor = (ConstructorInfo)resolver;
                //    var presenterType = presenterConstructor.DeclaringType;
                //    var presenterTypeReference = new CodeTypeReference(presenterType);
                //    var controlId = controlBuilder.ID;
                //    int index = Math.Max(0, buildMethod.Statements.Count - 1);
                //    buildMethod.Statements.Insert(index++, new CodeVariableDeclarationStatement(presenterTypeReference, string.Format("{0}Presenter", controlId),
                //        new CodeObjectCreateExpression(presenterTypeReference, new CodeVariableReferenceExpression(controlId))));
                //    //            System.Diagnostics.Debug.Write("Presenter Attaching...");
                //    //buildMethod.Statements.Insert(index++, new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(typeof(System.Diagnostics.Debug)), "WriteLine"), new CodePrimitiveExpression("Presenter Attaching...")));
                //}
                //else
                if (views is Type[] viewTypes)
                    foreach (var viewType in viewTypes)
                    {
                        var controlId = controlBuilder.ID;
                        var injection = new CodeMethodInvokeExpression(
                            new CodeMethodReferenceExpression(
                                new CodeTypeReferenceExpression(typeof(Presenters)),
                                "GetPresenterFor"),
                            new CodeTypeOfExpression(viewType),
                            new CodeVariableReferenceExpression(controlId));
                        //Presenters.GetPresenterFor(type, this);
                        int index = Math.Max(0, buildMethod.Statements.Count - 1);
                        buildMethod.Statements.Insert(index++, new CodeExpressionStatement(injection));
                    }
            }
        }
    }
}
