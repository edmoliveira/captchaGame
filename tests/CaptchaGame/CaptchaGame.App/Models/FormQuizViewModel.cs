using CaptchaGameLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace CaptchaGame.App.Core.Models
{
    public class FormQuizViewModel
    {
        public CaptchaGameModel CaptchaModel { get; set; }
        public string CaptchaId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Sex { get; set; }
        public bool QuizResult { get; set; }
    }
}
