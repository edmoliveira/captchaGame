using CaptchaGameLibrary.Interfaces;

namespace CaptchaGame.Interfaces
{
    /// <summary>
    /// Defines methods to create key for validator and to validate the key.
    /// </summary>
    public interface ICaptchaGameService
    {
        #region Methods

        /// <summary>
        /// Gets object to get the key used for validation.
        /// </summary>
        /// <returns>Returns interface IGame</returns>
        IGame GetGame();
        /// <summary>
        /// Method used for validates the key
        /// </summary>
        /// <param name="validatorKey">Encrypted key of the validator</param>
        /// <param name="gameResponse">Response of the client side</param>
        /// <returns>Returns true if validator key is valid</returns>
        bool Validate(string validatorKey, string gameResponse);

        #endregion
    }
}
