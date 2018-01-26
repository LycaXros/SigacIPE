using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGAC.Layers
{
    public static class GlobalVariables
    {
        public static string FTPServer => ConfigurationManager.AppSettings["ftpServer"].ToString();

        public static string FTPUser => ConfigurationManager.AppSettings["ftpUser"].ToString();

        public static string FTPPass => ConfigurationManager.AppSettings["ftpPass"].ToString();

        public static string OracleConnectionString => ConfigurationManager.ConnectionStrings["oracleCS"].ToString();

        public static string SQLServerConnectionString => ConfigurationManager.ConnectionStrings["sqlserverCS"].ToString();

        public static string ServerUrl => ConfigurationManager.AppSettings["urlServer"].ToString();

        public static string RecursosUrl => ConfigurationManager.AppSettings["urlRecursos"].ToString();

        public static string SoporteMail => ConfigurationManager.AppSettings["SoporteMail"].ToString();

    }
}
