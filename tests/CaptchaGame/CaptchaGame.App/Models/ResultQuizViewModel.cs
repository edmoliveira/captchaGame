namespace CaptchaGame.App.Core.Models
{
    public class ResultQuizViewModel
    {
        public bool CaptchaIsValid { get; set; }
        public string Message { get; internal set; }
    }
}
