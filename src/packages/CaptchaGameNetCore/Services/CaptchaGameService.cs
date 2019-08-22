using CaptchaGameLibrary;
using CaptchaGameLibrary.Interfaces;
using CaptchaGameLibrary.Models;
using CaptchaGameNetCore.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace CaptchaGameNetCore.Services
{
    /// <summary>
    /// Creates scripts (Client Side), key for validator and to validate the key.
    /// Creates the captchagame component.
    /// </summary>
    public sealed class CaptchaGameService : TagHelperComponent, ICaptchaGameService
    {
        #region Fields

        /// <summary>
        /// Object used for creating scripts (Client Side)
        /// </summary>
        private readonly IScriptManager scriptManager;
        /// <summary>
        ///  Object used for validating validator key
        /// </summary>
        private readonly IValidation validation;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public CaptchaGameService()
        {
            scriptManager = GameFactory.Instance.CreateScriptManager();
            validation = GameFactory.Instance.CreateValidation();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Synchronously executes the Microsoft.AspNetCore.Razor.TagHelpers.ITagHelperComponent with the given context and output.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        /// <returns>Task</returns>
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "body", StringComparison.Ordinal))
            {
                output.PostContent.AppendHtmlLine(scriptManager.GetMainScript());
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets object to get the key used for validation.
        /// </summary>
        /// <returns>Returns interface IGame</returns>
        public IGame GetGame()
        {
            return GameFactory.Instance.CreateGame();
        }

        /// <summary>
        /// Method used for validates the key
        /// </summary>
        /// <param name="validatorKey">Encrypted key of the validator</param>
        /// <param name="gameResponse">Response of the client side</param>
        /// <returns>Returns true if validator key is valid</returns>
        public bool Validate(string validatorKey, string gameResponse)
        {
            return validation.Validate(validatorKey, gameResponse);
        }

        /// <summary>
        /// Gets the game script, this script to control the game. (Client Side)
        /// </summary>
        /// <param name="model">Model to create the game script of the client side</param>
        /// <returns>Returns the script</returns>
        public string GetGameScript(CaptchaGameModel model)
        {
            return scriptManager.GetGameScript(model);
        }

        #endregion
    }
}