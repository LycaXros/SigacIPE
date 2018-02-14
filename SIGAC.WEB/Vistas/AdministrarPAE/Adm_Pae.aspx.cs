using System;
using SIGAC.Layers.Bussiness.Model;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Diagnostics;
using System.Net.Mail;
using System.Data.Common;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;

namespace SIGAC.WEB.Vistas
{
    public partial class Adm_Pae : System.Web.UI.Page
    {
        #region variables a utilizar 

        SigacEntities dbEntity;

        #endregion variables a utilizar 

        #region     Metodo Load de la Pagina de Recintos
        /// <summary>
        /// Metodo Load de la Pagina de Administrar PAE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            dbEntity = new SigacEntities();
            getdataAdministrarPAE();
            fillYears();
        }

        /// <summary>
        /// LLena el combobox de años
        /// </summary>
        private void fillYears()
        {
            try
            {
                var Years = dbEntity.SIEDU_PAE
                    .Where(x => x.PAE_ESTADO.CompareTo("1") == 0)
                .GroupBy(x => x.PAE_VIGENCIA)
                .Select(name => name.FirstOrDefault().PAE_VIGENCIA)
                .ToList();

                if (Years.Count == 0)
                    ActiveButtons(true);
                else
                    ActiveButtons(false);


                if (!Years.Contains(DateTime.Now.Year.ToString()))
                {
                    Years.Add(DateTime.Now.Year.ToString());
                }

                Years = Years.OrderByDescending(x => x).ToList();

                //using (var i = new Entities())
                //{
                //    var Years = from dominio in i.SIEDU_DOMINIO
                //                group dominio by dominio.VIGENTE into dom
                //                select dom
                //}

                foreach (var item in Years)
                {
                    ddlVigencia.Items.Add(item.ToString());
                }

                ddlVigencia.DataSource = Years;
                ddlVigencia.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ActiveButtons(bool val)
        {
            btnActivarVigencia.Visible = val;
            btnGenerarPAE.Visible = !val;
            btnGenerarPAE.Enabled = !val;
            btnActivarVigencia.Enabled = val;
        }
        #endregion  Metodo Load de la Pagina de Recintos

        #region    Metodo que te permite obtener los datos de la tabla /*/* para llenar el Web Grid View

        /// <summary>
        /// #region    Metodo que te permite obtener los datos de la tabla /*/* para llenar el Web Grid View
        /// </summary>
        private void getdataAdministrarPAE()
        {

            //stringSqlQuery = "SELECT * FROM /*/*";
            //gvAdministrarPae.DataSource = conseguirDataFromDatabase.getData(stringSqlQuery);
            //gvAdministrarPae.DataBind();

        }

        #endregion    Metodo que te permite obtener los datos de la tabla /*/* para llenar el Web Grid View

        #region    Evento Click del btnBuscar, para buscar informacion en la base de datos

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                //stringSqlQuery = "SELECT * FROM /*/* WHERE ID = :codigo";
                //gvAdministrarPae.DataSource = conseguirDataFromDatabase.getData(stringSqlQuery, "codigo", ddlVigencia.SelectedValue.ToString());
                //gvAdministrarPae.DataBind();
            }
            catch (Exception)
            {

            }

        }


        #endregion  Evento Click del btnBuscar, para buscar informacion en la base de datos

        protected void btnActivarVigencia_Click(object sender, EventArgs e)
        {
            btnGuardarVigenciaPae.CommandName = "ActivarPae";
            OpenModalDatosDocumentos();

        }

        private void OpenModalDatosDocumentos()
        {
            using (dbEntity = new SigacEntities())
            {
                var query =
                   (from dominio in dbEntity.SIEDU_DOMINIO
                    join tipoDominio in dbEntity.SIEDU_TIPO_DOMINIO on dominio.ID_TIPO_DOMINIO equals tipoDominio.ID_TIPO_DOMINIO
                    where tipoDominio.NOMBRE == "Documentos"
                    select dominio).ToList();

                var query2 =
                    dbEntity.SIEDU_DOMINIO
                    .Join(dbEntity.SIEDU_TIPO_DOMINIO,
                        dom => dom.ID_TIPO_DOMINIO,
                        type => type.ID_TIPO_DOMINIO,
                        (dom, type) => new { Dominio = dom, Tipo = type })
                        .Where(x => x.Tipo.NOMBRE == "Documentos")
                        .Select(x => x.Dominio)
                        .Distinct()
                        .ToList();


                ddlTipoDocumento.DataValueField = "ID_Dominio";
                ddlTipoDocumento.DataTextField = "NOMBRE";
                ddlTipoDocumento.DataSource = query;
                ddlTipoDocumento.DataBind();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "none", "OpenModal('idModal') ;", true);
        }

        protected void btnGuardarVigenciaPae_Click(object sender, EventArgs e)
        {

            if (!fuAnexo.HasFile)
                return;
            string comName = (sender as IButtonControl).CommandName;

            try
            {
                switch (comName)
                {
                    case "GenerarPae":
                        GenerarPae();
                        break;
                    case "ActivarPae":
                        ActivarVigencia();
                        GenerarPae();
                        break;
                    default:
                        throw new ArgumentException();
                }

            }
            catch (Exception ex)
            {
                Layers.Application.ExceptionUtility.LogException(ex, "Boton de Guardar Vigencia");
            }
        }

        private void GenerarPae()
        {
            string valueIndex = ddlVigencia.SelectedItem.Value;

            string tipoDocumento = ddlTipoDocumento.SelectedItem.Text;
            string numDoc = txtNumeroDocumento.Text.Trim();
            string obser = txtObservaciones.Text.Trim();
            DateTime fecha = DateTime.Parse(fechaDoc.Value);

            using (dbEntity = new SigacEntities())
            {
                var usuario = new Layers.Application.DatosUsu();

                string nombreArchivo = Path.GetFileName(fuAnexo.PostedFile.FileName);
                string extensionArchivo = Path.GetExtension(fuAnexo.PostedFile.FileName);
                Stream streamArchivo = fuAnexo.PostedFile.InputStream;

                string NewID = (dbEntity.SIEDU_ARCHIVO.Count() + 1).ToString();

                string nombreArchivoNuevo = string.Format("{3}{0}_{1}{2}", DateTime.Now.ToString("yyyy-MM-dd_HHmmss"), NewID, extensionArchivo, Enum.GetName(typeof(Layers.Application.classFTPServer.stringCarpetasFTP), Layers.Application.classFTPServer.stringCarpetasFTP.Docs));

                //rutaImagen = @"Imagenes/Upload/" + nombreArchivoNuevo;

                if (extensionArchivo.ToLower() == "pdf")
                {

                    Layers.Application.classFTPServer.subirArchivosAlFTP(nombreArchivo, extensionArchivo, streamArchivo, NewID, Layers.Application.classFTPServer.stringCarpetasFTP.Docs);

                }

                var archivo = new SIEDU_ARCHIVO()
                {

                    ARCH_NOMBRE = nombreArchivo,
                    ARCH_EXT = extensionArchivo,
                    ARCH_CONTENT_TYPE= tipoDocumento,
                    ARCH_TITULO = $"PDF=>PAE-{nombreArchivoNuevo}",
                    
                    ARCH_IP_CREA = usuario.IpUsuario,
                    ARCH_USU_CREA = usuario.UsuarioName,
                    ARCH_MAQUINA_CREA = usuario.MachineName,
                    ARCH_FECHA_CREA = usuario.Fecha,

                    ARCH_IP_MOD = usuario.IpUsuario,
                    ARCH_USU_MOD = usuario.UsuarioName,
                    ARCH_MAQUINA_MOD = usuario.MachineName,
                    ARCH_FECHA_MOD = usuario.Fecha

                };


                dbEntity.SIEDU_ARCHIVO.Add(archivo);
                dbEntity.SaveChanges();
                var novedad = new SIEDU_NOVEDAD_PAE()
                {
                    NOVE_PAE = int.Parse(valueIndex),
                    NOVE_FECHA = DateTime.Now,
                    NOVE_PROCEDI = "N/A",
                    NOVE_TPO_DOC = tipoDocumento,
                    NOVE_NRO_DOC = numDoc,
                    NOVE_OBSERVA = obser,
                    NOVE_FECHA_DOC = fecha,
                    NOVE_ANEXO_PDF = archivo.ARCH_ID,


                    NOVE_IP_CREA = usuario.IpUsuario,
                    NOVE_USU_CREA = usuario.UsuarioName,
                    NOVE_MAQUINA_CREA = usuario.MachineName,
                    NOVE_FECHA_CREA = usuario.Fecha,

                    NOVE_IP_MOD = usuario.IpUsuario,
                    NOVE_USU_MOD = usuario.UsuarioName,
                    NOVE_MAQUINA_MOD = usuario.MachineName,
                    NOVE_FECHA_MOD = usuario.Fecha

                };

                dbEntity.SIEDU_NOVEDAD_PAE
                    .Add(novedad);

                dbEntity.SaveChanges();

            }
        }

        private void ActivarVigencia()
        {
            string valueIndex = ddlVigencia.SelectedItem.Value;
            using (dbEntity = new SigacEntities())
            {
                var usuario = new Layers.Application.DatosUsu();

                dbEntity.SIEDU_PAE
                    .Add(new SIEDU_PAE()
                    {
                        PAE_ESTADO = "En Construccion",
                        PAE_VIGENCIA = valueIndex,
                        PAE_NECE_YA_IMPORTADA = string.Empty,

                        PAE_IP_CREA = usuario.IpUsuario,
                        PAE_USU_CREA = usuario.UsuarioName,
                        PAE_MAQUINA_CREA = usuario.MachineName,
                        PAE_FECHA_CREA = usuario.Fecha,

                        PAE_IP_MOD = usuario.IpUsuario,
                        PAE_USU_MOD = usuario.UsuarioName,
                        PAE_MAQUINA_MOD = usuario.MachineName,
                        PAE_FECHA_MOD = usuario.Fecha

                    });

                dbEntity.SaveChanges();

            }
        }

        protected void btnGenerarPAE_Click(object sender, EventArgs e)
        {
            btnGuardarVigenciaPae.CommandName = "GenerarPae";
            OpenModalDatosDocumentos();
        }
    }
}