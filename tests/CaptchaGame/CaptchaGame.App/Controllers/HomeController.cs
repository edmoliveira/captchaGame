using CaptchaGame.App.Core.Models;
using CaptchaGame.Controllers;
using CaptchaGameLibrary;
using CaptchaGameLibrary.Models;
using CoreUITest.Extesions;
using System;
using System.Web.Mvc;
using System.Linq;

namespace CaptchaGame.App.Controllers
{
    public class HomeController : CaptchaGameController
    {
        private const string QuizSessionKey = "QuizCaptchaGame";

        public ActionResult Index()
        {
            return View(new FormQuizViewModel { QuizResult = true, CaptchaModel = CreateCaptcha() });
        }

        public ActionResult Save(FormQuizViewModel model)
        {
            var resultModel = new ResultQuizViewModel();

            try
            {
                var validatorKey = HttpContext.Session.PullOutString(QuizSessionKey);

                if (ModelState.IsValid)
                {
                    resultModel.CaptchaIsValid = CaptchaService.Validate(validatorKey, model.CaptchaId);
                    resultModel.Message = "Successfully saved Quiz";
                }
            }
            catch (CaptchaGameException)
            {
                //could be an attempt at a robot
                //Messages: "Validator Key isn't valid" or "Game Response isn't valid"
                resultModel.CaptchaIsValid = false;
                resultModel.Message = "Invalid Captcha";
            }
            catch (Exception)
            {
                resultModel.CaptchaIsValid = false;
                resultModel.Message = "An error has occurred. Please contact your system administrator.";
            }

            if (resultModel.CaptchaIsValid)
            {
                return View("Result", resultModel);
            }
            else
            {
                model.CaptchaId = string.Empty;
                model.CaptchaModel = CreateCaptcha();

                ViewBag.CaptchaError = resultModel.Message;

                return View("Index", model);
            }
        }

        private CaptchaGameModel CreateCaptcha()
        {
            CaptchaGameModel captcha = new CaptchaGameModel
            {
                Game = CaptchaService.GetGame()
            };

            HttpContext.Session[QuizSessionKey] = captcha.Game.ValidatorKey;

            return captcha;
        }
    }
}
