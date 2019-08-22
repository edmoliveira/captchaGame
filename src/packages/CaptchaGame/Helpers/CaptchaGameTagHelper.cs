using CaptchaGame.Interfaces;
using CaptchaGameLibrary.Models;
using System.Web.Mvc;

namespace CaptchaGame.Helpers
{
    /// <summary>
    /// Extension of the HtmlHelper class (CaptchaGame).
    /// </summary>
    public static class CaptchaGameTagHelper
    {
        /// <summary>
        /// Creates the main script, this script to load the game (Client Side).
        /// </summary>
        /// <param name="htmlHelper">Supports the rendering of HTML controls in a view.</param>
        /// <returns>Retuns MvcHtmlString</returns>
        public static MvcHtmlString GameTagHelper(this HtmlHelper htmlHelper)
        {
            IICaptchaGameService captchaService = (IICaptchaGameService)Application.GetICaptchaGameService(htmlHelper.ViewContext.HttpContext);

            return MvcHtmlString.Create(captchaService.GetMainScript());
        }

        /// <summary>
        /// Creates the game script, this script to control the game. (Client Side)
        /// </summary>
        /// <param name="htmlHelper">Supports the rendering of HTML controls in a view.</param>
        /// <param name="Info">Model to create the game script of the client side</param>
        /// <returns>Retuns MvcHtmlString</returns>
        public static MvcHtmlString CanvasTagHelper(this HtmlHelper htmlHelper, CaptchaGameModel Info)
        {
            IICaptchaGameService captchaService = (IICaptchaGameService)Application.GetICaptchaGameService(htmlHelper.ViewContext.HttpContext);

            var builder = new TagBuilder("script")
            {
                InnerHtml = captchaService.GetGameScript(Info)
            };

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
