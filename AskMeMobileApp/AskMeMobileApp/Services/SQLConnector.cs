using AskMeMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AskMeMobileApp.Services
{
   public class SQLConnector
    {
        public string GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return path;
        }

        public static SQLConnector CreateConnector()
        {
            return new SQLConnector();
        }

    }
}
