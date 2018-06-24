Getting started with WebPx.Presentation.Unity
-------------------------------------------

WebPx.Presentation.Unity allows you to configure the Application Services in a Unity Container and follow the Unity standard procedures for Dependency Injection

To get started in a WebApplication, just add a call to PresentationUnityConfig.Register() in the Application_Start method of Global.asax.cs. 

Modify the App_Start\PresentationUnityConfig.cs accordingly

e.g.
 
public class Global : System.Web.HttpApplication
{
  void Application_Start()
  {
    ...
    PresentationUnityConfig.Register();                           // <----- Add this line
    ...
  }           
}  
