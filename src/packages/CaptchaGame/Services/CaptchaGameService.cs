using CaptchaGame.Interfaces;
using CaptchaGameLibrary;
using CaptchaGameLibrary.Interfaces;
using CaptchaGameLibrary.Models;

namespace CaptchaGame.Services
{
    /// <summary>
    /// Creates scripts (Client Side), key for validator and to validate the key.
    /// </summary>
    internal sealed class CaptchaGameService : IICaptchaGameService
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
        ///  Gets the main script, this script to load the game. (Client Side)
        /// </summary>
        /// <returns>Returns the script</returns>
        public string GetMainScript()
        {
            return scriptManager.GetMainScript();
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