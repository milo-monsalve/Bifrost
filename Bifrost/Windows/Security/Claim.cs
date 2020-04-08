namespace Bifrost.Windows.Security
{
    public class Claim
    {
        public static string Get(string text)
        {
            return System.Text.Encoding.Unicode.GetString(System.Convert.FromBase64String(text));
        }

        public static string Set(string text){
            return System.Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(text));
        }
    }
}