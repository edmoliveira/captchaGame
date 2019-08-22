using CaptchaGameLibrary.Models;
using CaptchaGameNetCore.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CaptchaGameNetCore.Helpers
{
    /// <summary>
    /// Creates the captchagame component.
    /// </summary>
    [HtmlTargetElement("captchagame-content")]
    public class CanvasTagHelper : TagHelper
    {
        #region Properties

        /// <summary>
        /// Data used for creating the game script of the client side
        /// </summary>
        public CaptchaGameModel Info { get; set; }

        #endregion

        #region Fields

        /// <summary>
        /// Creates the game script
        /// </summary>
        private readonly ICaptchaGameService captchaService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="captchaService">Creates the game script</param>
        public CanvasTagHelper(ICaptchaGameService captchaService)
        {
            this.captchaService = captchaService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Synchronously executes the Microsoft.AspNetCore.Razor.TagHelpers.TagHelper with the given context and output.
        /// </summary>
        /// <param name="context"> Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "script";
            output.Content.SetHtmlContent(captchaService.GetGameScript(Info));

            output.TagMode = TagMode.StartTagAndEndTag;
        }

        #endregion
    }
}
