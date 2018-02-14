using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SIGAC.Layers.Application
{
    public static class classFTPServer
    {

        /// <summary>
        /// Enumeracion de las carpetas dentro del FTP
        /// </summary>
        public enum stringCarpetasFTP : int
        {
            Docs,
            Imagenes,
            Img,
            Libros,
            Organos
        }

        /// <summary>
        /// Propiedad que te permite conseguir la direccion del FTP
        /// </summary>
        private static string stringFTPServer => ConfigurationManager.AppSettings["ftpRecursos"].ToString();

        /// <summary>
        /// Propiedad que te permite conseguir el usuario del FTP
        /// </summary>
        private static string stringFTPUsuario => ConfigurationManager.AppSettings["ftpUsuario"].ToString();

        /// <summary>
        /// Propiedad que te permite conseguir la contraseña del FTP
        /// </summary>
        private static string stringFTPContraseña => ConfigurationManager.AppSettings["ftpContraseña"].ToString();

        /// <summary>
        /// Permite subir archivos al FTP
        /// </summary>
        /// <param name="stringNombreArchivo">Nombre del archivo a subir</param>
        /// <param name="streamArchivo">InputStream del archivo a subir</param>
        /// <param name="stringCarpetaFTP">Carpeta a la cual sera subido</param>
        public static void subirArchivosAlFTP(string stringNombreArchivo, string stringExtension, Stream streamArchivo, string IdRelacion, stringCarpetasFTP stringCarpetaFTP = stringCarpetasFTP.Imagenes)
        {

            try
            {

                //Crear el request al servidor FTP
                FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(stringFTPServer + conseguirCarpetaFTP(stringCarpetaFTP) + string.Format("{3}{0}_{1}{2}", DateTime.Now.ToString("yyyy-MM-dd_HHmmss"), IdRelacion, stringExtension, Enum.GetName(typeof(stringCarpetasFTP), stringCarpetaFTP) ));

                //Decirle que el metodo es el de Subir archivos
                ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

                //Pasarle los credenciales del FTP
                ftpWebRequest.Credentials = new NetworkCredential(stringFTPUsuario, stringFTPContraseña);
                ftpWebRequest.UsePassive = true;

                //Decirle que el tipo de archivos a subir sera Binario o Byte
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.EnableSsl = false;

                //Pasar el stream del archivo al stream del request del FTP
                using (var requestStream = ftpWebRequest.GetRequestStream())
                {
                    CopyStream(streamArchivo, requestStream);
                }

                //Si esto falla, entonces el archivo no fue subido exitosamente
                FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                ftpWebResponse.Close();

            }
            catch (WebException) { }

        }

        /// <summary>
        /// Permite pasar el Stream del archivo original al Stream de la solicitud
        /// </summary>
        /// <param name="input">Stream del archivo original </param>
        /// <param name="output">Stream de la solicitud</param>
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];

            int read;

            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        /// <summary>
        /// Permite conseguir la carpeta a la cual se va a subir el archivo segun el tipo de archivo
        /// </summary>
        /// <param name="stringCarpeta">Enumeracion de las carpetas de archivos</param>
        /// <returns>Carpeta del archivo dentro del FTP</returns>
        private static string conseguirCarpetaFTP(stringCarpetasFTP stringCarpeta = stringCarpetasFTP.Imagenes)
        {
            string rutaCarpeta;

            //Busca la carpeta especificada
            switch (stringCarpeta)
            {
                case stringCarpetasFTP.Docs:
                    {
                        rutaCarpeta = "Docs/";
                        break;
                    }
                case stringCarpetasFTP.Libros:
                    {
                        rutaCarpeta = "Docs/Libros/";
                        break;
                    }
                case stringCarpetasFTP.Organos:
                    {
                        rutaCarpeta = "Docs/Organos/";
                        break;
                    }
                case stringCarpetasFTP.Img:
                    {
                        rutaCarpeta = "img/";
                        break;
                    }
                case stringCarpetasFTP.Imagenes:
                default:
                    {
                        rutaCarpeta = "Imagenes/Upload/";
                        break;
                    }
            }

            return rutaCarpeta;
        }
    }
}