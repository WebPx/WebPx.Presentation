Getting started with WebPx.Presentation.Web
-------------------------------------------

WebPx.Presentation.Web is the implementation for web apps of WebPx.Presentation, which extends it for use with a User Interface developed for a web application.

WebPx.Presentation is an implementation of the Model-View-Presenter pattern. To get started, just add a call to PresentationConfig.Register() in the Application_Start method of Global.asax.cs 
and the WebPx.Presentation framework will use this to attach presenters at compilation time to the views.

e.g.
 
public class Global : System.Web.HttpApplication
{
  void Application_Start()
  {
    ...
    PresentationConfig.Register();                           // <----- Add this line
    ...
  }           
}  
