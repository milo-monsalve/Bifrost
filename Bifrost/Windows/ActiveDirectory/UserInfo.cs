using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace Bifrost.Windows.ActiveDirectory
{

    public class UserData
    {
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Employeeid { get; set; }
    }

    public static class UserInfo
    {
        public static UserData GetInfo(string user,string path)
        {
            DirectoryEntry Entry = new DirectoryEntry(path);
            DirectorySearcher Searcher = new DirectorySearcher(Entry);
            Searcher.Filter = "(&(objectClass=user)(samaccountname="+user+"))";
            UserData Result = new UserData();
            SearchResultCollection Item = Searcher.FindAll();

            if(Item.Count > 0)
            {
                Result.Department = GetProperty(Item[0], "department");
                Result.DisplayName = GetProperty(Item[0], "sisplayname");
                Result.Employeeid = GetProperty(Item[0], "employeeid");
                Result.Mail = GetProperty(Item[0], "mail");
                Result.Region = GetProperty(Item[0], "l");
                Result.Title = GetProperty(Item[0], "title");
            }

            return Result;
        }

        private static string GetProperty(SearchResult result,string property)
        {
            if (result.Properties.Contains(property))
                return result.Properties[property][0].ToString();

            return string.Empty;
        }
    }
}
