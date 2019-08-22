using CaptchaGameLibrary.Interfaces;
using CaptchaGameLibrary.Models;

namespace CaptchaGameNetCore.Interfaces
{
    #region Methods

    /// <summary>
    /// Defines methods to create scripts (Client Side), key for validator and to validate the key.
    /// </summary>
    public interface ICaptchaGameService
    {
        /// <summary>
        /// Gets object to get the key used for validation.
        /// </summary>
        /// <returns>Returns interface IGame</returns>
        IGame GetGame();
        /// <summary>
        /// Gets the game script, this script to control the game. (Client Side)
        /// </summary>
        /// <param name="model">Model to create the game script of the client side</param>
        /// <returns>Returns the script</returns>
        string GetGameScript(CaptchaGameModel model);
        /// <summary>
        /// Method used for validates the key
        /// </summary>
        /// <param name="validatorKey">Encrypted key of the validator</param>
        /// <param name="gameResponse">Response of the client side</param>
        /// <returns>Returns true if validator key is valid</returns>
        bool Validate(string validatorKey, string gameResponse);
    }

    #endregion
}
