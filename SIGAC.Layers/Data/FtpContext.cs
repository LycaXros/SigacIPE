using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.Configuration;

namespace SIGAC.Layers.Data
{
    public static class FtpContext
    {
        private static string server => ConfigurationManager.AppSettings["ftpServer"].ToString();

        private static string user => ConfigurationManager.AppSettings["ftpUser"].ToString();

        private static string pass => ConfigurationManager.AppSettings["ftpPass"].ToString();

        public enum carpetas : int
        {
            Root
        }

        private static string findFolder(carpetas carpeta)
        {
            string folder;
            switch (carpeta)
            {
                case carpetas.Root:
                default:
                    folder = "";
                    break;
            }

            return folder;
        }

        private static void copyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];

            int read;

            while ((read = input.Read(buffer, 0, buffer.Length)) > 0 )
            {
                output.Write(buffer, 0, read);
            }
        }

        public static void sendFile(Stream fileStream,string fileName, string fileExtention, int id, carpetas folder = carpetas.Root)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + findFolder(folder) + fileName + fileExtention);

                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(user, pass);

                request.UseBinary = true;
                request.UsePassive = true;
                request.EnableSsl = false;

                using (var requestStream = request.GetRequestStream())
                {
                    copyStream(fileStream, requestStream);
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();
            }
            catch (WebException webException)
            {

                throw webException;
            }
        }
    }
}
