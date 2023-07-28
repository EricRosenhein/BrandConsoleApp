﻿using IniParser.Model;
using IniParser;
using System.Xml.Linq;

namespace BrandConsoleApp.Util
{
    public class Utilities
    {

        private static string ConnectionString = "";

        private static string ServerName = "localhost";
        private static string DbName = "test";
        private static string LoginName = "";
        private static string Password = "";

        public static void SetServerName(string serverName)
        {
            ServerName = serverName;
        }

        public static void SetDBName(string dbName)
        {
            DbName = dbName;
        }

        public static void SetLoginName(string loginName)
        {
            LoginName = loginName;
        }

        public static void SetPassword(string password)
        {
            Password = password;
        }

        public static void SetConnectionString()
        {
            /* ConnectionString = "Server=tcp:" + serverName +
             "Database=" + dbName + ";User ID=" + loginNm + ";" +
             "Password=" + passwd + ";Encrypt=True;" +
             "TrustServerCertificate=False;Connection Timeout=30;"; */

            /*ConnectionString = "Server = " + serverName + "; Database = " + dbName + "; User Id = " +
                loginNm + "; Password = " + passwd + ";"; */

            ConnectionString = "Server = " + ServerName + "; Database = " + DbName + "; Encrypt=False; Trusted_Connection = True;";
        }

        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        public static void EstablishConnection(string filePath)
        {
            // Need to read the file which will have info like this
            // serverName=...
            // dbName=...
            // loginName=...
            // password=...

            // and set the above static variables from this file

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(filePath);

            SetServerName(data["Server"]["ServerName"]);
            SetDBName(data["Server"]["DBName"]);
            SetLoginName(data["Server"]["LoginName"]);
            SetPassword(data["Server"]["Password"]);

            SetConnectionString();

        }
    }
}
