namespace CoffeeShop
{
    using System;
    using System.Text;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using NLog;

    public class Global : HttpApplication
    {
        #region Fields

        private Logger _logger;

        #endregion

        #region Properties

        private Logger Logger => _logger ?? (_logger = LogManager.GetLogger("CoffeeShop"));

        #endregion

        #region Methods

        protected void Application_Error(object sender, EventArgs e)
        {
            //get reference to the source of the exception chain
            var lastException = Server.GetLastError().GetBaseException();

            try
            {
                if (HttpContext.Current == null)
                {
                    // No http context, so this error does not come from a request a browser made, so we cant forward to error handler page.
                    // Log error and return.
                    Logger.Error(lastException, "An exception was caught in Application_Error, and HttpContext.Current == null.");
                    return;
                }

                // Log error
                Logger.Error(lastException, FormatMessageWithRequestDetails("An exception was caught in Application_Error."));
            }

            catch (Exception ex)
            {

                try
                {
                    Logger.Error(ex, "An exception was caught while handling an error in Application_Error error handler.");
                }

                catch
                {
                    // Ignore errors that occure when logging errors to prevent infinite loops.
                }
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static string FormatMessageWithRequestDetails(string message)
        {
            var errorBuilder = new StringBuilder().AppendLine(message);

            if (HttpContext.Current != null)
            {
                var httpContext = HttpContext.Current;
                var request = HttpContext.Current.Request;
                errorBuilder.AppendLine($"\tRemote IP: {httpContext.Request.ServerVariables["REMOTE_HOST"]}")
                            .AppendLine($"\tUserAgent: {request.UserAgent}")
                            .AppendLine($"\tUrl: {request.Url.OriginalString}")
                            .AppendLine($"\tUsername: {httpContext.User.Identity.Name}")
                            .AppendLine($"\tPosted data: {request.Form}");
            }

            return errorBuilder.ToString();
        }

        #endregion
    }
}