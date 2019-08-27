using System.Web;

namespace CoreUITest.Extesions
{
    public static class SessionCoreExtensions
    {
        public static string PullOutString(this HttpSessionStateBase session, string key)
        {
            object value = session[key];

            session.Remove(key);

            return value?.ToString();
        }
    }
}
