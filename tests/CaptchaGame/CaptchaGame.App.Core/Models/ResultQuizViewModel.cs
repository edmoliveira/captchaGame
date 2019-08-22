using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaptchaGame.App.Core.Models
{
    public class ResultQuizViewModel
    {
        public bool CaptchaIsValid { get; set; }
        public string Message { get; internal set; }
    }
}
