using CaptchaGame.App.Core.Extensions;
using CaptchaGame.App.Core.Models;
using CaptchaGameLibrary;
using CaptchaGameLibrary.Models;
using CaptchaGameNetCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CaptchaGame.App.Core.Controllers
{
    public class HomeController : Controller
    {
        private const string QuizSessionKey = "QuizCaptchaGame";

        private readonly ICaptchaGameService captchaService;

        public HomeController(ICaptchaGameService captchaService)
        {
            this.captchaService = captchaService;
        }

        public IActionResult Index()
        {
            return View(new FormQuizViewModel {  CaptchaModel = CreateCaptcha() });
        }

        public IActionResult Save(FormQuizViewModel model)
        {
            var resultModel = new ResultQuizViewModel();

            try
            {
                var validatorKey = HttpContext.Session.PullOutString(QuizSessionKey);

                if (ModelState.IsValid)
                {
                    resultModel.CaptchaIsValid = captchaService.Validate(validatorKey, model.CaptchaId);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private CaptchaGameModel CreateCaptcha()
        {
            CaptchaGameModel captcha = new CaptchaGameModel
            {
                Game = captchaService.GetGame()
            };

            HttpContext.Session.SetString(QuizSessionKey, captcha.Game.ValidatorKey);

            return captcha;
        }
    }
}
