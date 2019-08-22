using Microsoft.AspNetCore.Http;

namespace CaptchaGame.App.Core.Extensions
{
    public static class SessionCoreExtension
    {
        public static string PullOutString(this ISession session, string key)
        {
            string value = session.GetString(key);

            session.Remove(key);

            return value;
        }
    }
}
