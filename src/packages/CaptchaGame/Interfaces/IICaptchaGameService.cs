using CaptchaGameLibrary.Models;

namespace CaptchaGame.Interfaces
{
    /// <summary>
    /// Defines methods to create scripts (Client Side).
    /// </summary>
    internal interface IICaptchaGameService: ICaptchaGameService
    {
        #region Methods

        /// <summary>
        ///  Gets the main script, this script to load the game. (Client Side)
        /// </summary>
        /// <returns>Returns the script</returns>
        string GetMainScript();
        /// <summary>
        /// Gets the game script, this script to control the game. (Client Side)
        /// </summary>
        /// <param name="model">Model to create the game script of the client side</param>
        /// <returns>Returns the script</returns>
        string GetGameScript(CaptchaGameModel model);

        #endregion
    }
}
