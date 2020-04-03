using System.DirectoryServices;

namespace Bifrost.Windows.ActiveDorectory
{
     public class UserValidator
    {
        public static bool ValidateUser(string User, string Pwd,string Host,string Path)
        {
            //Armamos la cadena completa de Host y User
            string domainAndUsername = Host + @"\" + User.Trim();
            //Creamos un objeto DirectoryEntry al cual le pasamos el URL, Host/User y la contraseña
            DirectoryEntry entry = new DirectoryEntry(Path, domainAndUsername, Pwd);
            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);
                //Verificamos que los datos de logeo proporcionados son correctos
                SearchResult result = search.FindOne();
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}