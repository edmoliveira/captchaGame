using CaptchaGame.Interfaces;
using CaptchaGame.Services;
using System;

namespace CaptchaGame
{
    /// <summary>
    /// Factory used for creating services.
    /// </summary>
    internal sealed class ServiceFactory
    {
        #region Properties

        /// <summary>
        /// Lazy initialization of the ServiceFactory instance.
        /// </summary>
        private static readonly Lazy<ServiceFactory> lazy = new Lazy<ServiceFactory>(() => new ServiceFactory());

        /// <summary>
        /// Singleton
        /// </summary>
        public static ServiceFactory Instance => lazy.Value;

        #endregion

        #region Constructors

        /// <summary>
        /// private constructor
        /// </summary>
        private ServiceFactory() { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates an instance of the CaptchaGameService class.
        /// </summary>
        /// <returns>Returns interface ICaptchaGameService</returns>
        public ICaptchaGameService CreateCaptchaGameService()
        {
            return new CaptchaGameService();
        }

        #endregion
    }
}
