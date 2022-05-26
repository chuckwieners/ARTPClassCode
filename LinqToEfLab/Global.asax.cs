using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LinqToEfLab
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //Runs when the domain is called from the server - Initializes all settings
        //Points to the files in the App_Start folder in the MVC Layer
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //application_error does not appear by default, we must add it
        //Application_Error() is an event handler that responds to any Error EVENT thrown at the application level
        //By default in a deployed application, this will be handled by the customErrors Section in the web.config (defaults to On)
        //See custom errors in the ROOT web.config
        //and will return the file in ~/Views/Shared/Error.cshtml
        //Convention for MVC event handlers: protected void PartOfTheSite_Event()
        //Convention for Event Driven Application (EVA) event handlers: protected void PartOfTheSite_Event(object sender, EventArgs args)
        protected void Application_Error()
        {
            ////Set 404 HTTP exceptions to be handled by IIS server (behavior can be specified in the HttpErrors seciont in the web.config)
            //var error = Server.GetLastError();
            //if ((error as HttpException)?.GetHttpCode() == 404)
            //{
            //    //since the last error was retrieved, lets remove the error from the server log
            //    Server.ClearError();
            //    Response.StatusCode = 404;
            //    Response.Redirect("~/Errors/PageNotFound404");
            //}

            //Response.Redirect("~/Errors/General");
            //Uncomment BEFORE Deployment
            //With this code active, you will not see the ASP.NET Error messages during debugging.
        }

    }
}
