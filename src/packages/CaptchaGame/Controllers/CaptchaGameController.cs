using CaptchaGame.Interfaces;
using System.Web.Mvc;

namespace CaptchaGame.Controllers
{
    /// <summary>
    /// Controller used for Captcha Game.
    /// </summary>
    public abstract class CaptchaGameController : Controller
    {
        /// <summary>
        /// Creates key for validator and to validate the key.
        /// </summary>
        protected ICaptchaGameService CaptchaService => Application.GetICaptchaGameService(HttpContext);
    }
}
