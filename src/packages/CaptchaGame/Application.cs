using CaptchaGame.Interfaces;
using System.Web;

namespace CaptchaGame
{
    internal static class Application
    {
        public static ICaptchaGameService GetICaptchaGameService(HttpContextBase httpContext)
        {
            if (httpContext.ApplicationInstance.Application["CaptchaGameService"] == null)
            {
                httpContext.ApplicationInstance.Application["CaptchaGameService"] = ServiceFactory.Instance.CreateCaptchaGameService();
            }

            return (ICaptchaGameService)httpContext.ApplicationInstance.Application["CaptchaGameService"];
        }
    }
}
