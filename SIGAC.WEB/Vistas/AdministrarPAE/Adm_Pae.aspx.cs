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
using System.Data.Entity.Validation;

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
            if (IsPostBack)
                return;
            dbEntity = new SigacEntities();
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
                    .Where(x => x.PAE_ESTADO.CompareTo("C") == 0)
                .GroupBy(x => x.PAE_VIGENCIA)
                .Select(name => name.FirstOrDefault().PAE_VIGENCIA)
                .ToList();



                if (!Years.Contains(DateTime.Now.Year.ToString()))
                {
                    Years.Add(DateTime.Now.Year.ToString());
                }

                Years = Years.OrderByDescending(x => x).ToList();
                ddlVigencia.DataSource = Years;
                ddlVigencia.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ActiveButtons(string estado)
        {
            btnActivarVigencia.Visible = false;
            btnGenerarPAE.Visible = false;
            btnGenerarPAE.Enabled = false;
            btnActivarVigencia.Enabled = false;

            switch (estado)
            {
                case ConstantesPae.EnModificacion:
                case ConstantesPae.EnConstruccion:
                    btnGenerarPAE.Visible = true;
                    btnGenerarPAE.Enabled = true;
                    break;
                case ConstantesPae.Cerrada:
                    btnActivarVigencia.Enabled = true;
                    btnActivarVigencia.Visible = true;
                    break;

            }

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
                string vigencia = ddlVigencia.SelectedItem.Value;
                using (dbEntity = new SigacEntities())
                {
                    var otro = dbEntity.SIEDU_PAE
                        .Where(x => x.PAE_VIGENCIA.Equals(vigencia))
                        .Select(x => x).FirstOrDefault();

                    // var ot2 = otro.SIEDU_NOVEDAD_PAE as List<SIEDU_NOVEDAD_PAE>;

                    var query = dbEntity.SIEDU_PAE
                        .Join(dbEntity.SIEDU_NOVEDAD_PAE,
                                Pae => Pae.PAE_PAE, Novedad => Novedad.NOVE_PAE,
                                (Pae, Novedad) => new { Pae, Novedad })

                        .Where(x => x.Pae.PAE_VIGENCIA.Equals(vigencia))
                        .Select(x => x.Novedad)
                        .ToList()
                        .Join(dbEntity.SIEDU_ARCHIVO,
                            novedad => novedad.NOVE_ANEXO_PDF,
                            arch => arch.ARCH_ID,
                            (novedad, arch) => new
                            {
                                Vigencia = novedad.SIEDU_PAE.PAE_VIGENCIA,
                                Procedimiento = novedad.NOVE_PROCEDI,
                                Tipo_Documento = novedad.NOVE_TPO_DOC,
                                Numero_Documento = novedad.NOVE_NRO_DOC,
                                Fecha_Documento = novedad.NOVE_FECHA_DOC.ToShortDateString(),
                                Observacion = novedad.NOVE_OBSERVA,
                                Link = Layers.GlobalVariables.RecursosUrl + arch.ARCH_TITULO.Substring(arch.ARCH_TITULO.IndexOf('-')+1),
                                Titulo = arch.ARCH_TITULO,
                                Fecha = novedad.NOVE_FECHA.ToShortDateString(),
                                Usuario = novedad.NOVE_USU_MOD
                            }).ToList()
                            .OrderBy(x =>x.Fecha).ToList();

                    string estado =
                        dbEntity.SIEDU_PAE
                        .Where(x => x.PAE_VIGENCIA.Equals(vigencia))
                        .Select(x => x.PAE_ESTADO).First();
                    ActiveButtons(estado);
                    
                    gvAdministrarPae.DataSource = query;
                    gvAdministrarPae.DataBind();
                }
            }
            catch (Exception ex)
            {
                Layers.Application.ExceptionUtility.LogException(ex, "Buscando datos del CONTEXT, usando el DropDownList con las vigencias");
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
                Response.RedirectToRoute("PAE.Administrar");
            }
            catch (Exception ex)
            {
                Layers.Application.ExceptionUtility.LogException(ex, "Boton de Guardar Vigencia");
            }
        }

        private void GenerarPae()
        {
            string valueIndex = ddlVigencia.SelectedItem.Value;

            //string tipoDocumento = ddlTipoDocumento.SelectedItem.Text;
            string tipoDocumento = "Prueba";
            string numDoc = txtNumeroDocumento.Text.Trim();
            string obser = txtObservaciones.Text.Trim();
            DateTime fecha = DateTime.Parse(fechaDoc.Value);

            using (dbEntity = new SigacEntities())
            {
                var usuario = new Layers.Application.DatosUsu();

                string nombreArchivo = Path.GetFileName(fuAnexo.PostedFile.FileName);
                string extensionArchivo = Path.GetExtension(fuAnexo.PostedFile.FileName);
                Stream streamArchivo = fuAnexo.PostedFile.InputStream;

                int NewID = (dbEntity.SIEDU_ARCHIVO.Count() + 1);

                string nombreArchivoNuevo = string.Format("{3}{0}_{1}{2}", DateTime.Now.ToString("yyyy-MM-dd_HHmmss"), NewID, extensionArchivo, Enum.GetName(typeof(Layers.Data.FtpContext.carpetas), Layers.Data.FtpContext.carpetas.Root));

                //rutaImagen = @"Imagenes/Upload/" + nombreArchivoNuevo;

                if (extensionArchivo.ToLower() == ".txt")
                {

                    Layers.Data.FtpContext.sendFile(streamArchivo, nombreArchivo, extensionArchivo, NewID, Layers.Data.FtpContext.carpetas.Root);

                }

                var archivo = new SIEDU_ARCHIVO()
                {

                    ARCH_NOMBRE = nombreArchivo,
                    ARCH_EXT = extensionArchivo,
                    ARCH_CONTENT_TYPE = tipoDocumento,
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
                string tituloCompleto = $"PDF=>PAE-{nombreArchivoNuevo}";
                int archID = dbEntity.SIEDU_ARCHIVO
                    .Where(x => x.ARCH_TITULO.Equals(tituloCompleto))
                    .Select(x => x.ARCH_ID).First();
                int paeID = dbEntity.SIEDU_PAE
                    .Where(x => x.PAE_VIGENCIA.Equals(valueIndex))
                    .Select(x => x.PAE_PAE).First();
                var novedad = new SIEDU_NOVEDAD_PAE()
                {
                    NOVE_PAE = paeID,
                    NOVE_FECHA = DateTime.Now,
                    NOVE_PROCEDI = "N/A",
                    NOVE_TPO_DOC = tipoDocumento,
                    NOVE_NRO_DOC = numDoc,
                    NOVE_OBSERVA = obser,
                    NOVE_FECHA_DOC = fecha,
                    NOVE_ANEXO_PDF = archID,


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

                var pae = dbEntity.SIEDU_PAE
                    .Where(x => x.PAE_VIGENCIA.Equals(valueIndex))
                    .Select(x => x).First();
                if (pae.PAE_ESTADO.Equals(ConstantesPae.EnConstruccion) || pae.PAE_ESTADO.Equals(ConstantesPae.Cerrada))
                
                    pae.PAE_ESTADO = ConstantesPae.Cerrada;
                
                else if (pae.PAE_ESTADO.Equals(ConstantesPae.Cerrada))
                    pae.PAE_ESTADO = ConstantesPae.EnModificacion;

                pae.PAE_IP_MOD = usuario.IpUsuario;
                pae.PAE_USU_MOD = usuario.UsuarioName;
                pae.PAE_MAQUINA_MOD = usuario.MachineName;
                pae.PAE_FECHA_MOD = usuario.Fecha;
                dbEntity.SaveChanges();

            }
        }

        private void ActivarVigencia()
        {
            try
            {

                string valueIndex = ddlVigencia.SelectedItem.Value;

                using (dbEntity = new SigacEntities())
                {
                    bool existePae = dbEntity.SIEDU_PAE
                        .Where(x => x.PAE_VIGENCIA.Equals(valueIndex))
                        .Count() > 0;

                    if (existePae)
                        return;

                    var usuario = new Layers.Application.DatosUsu();
                    var PAE = new SIEDU_PAE()
                    {
                        PAE_ESTADO = ConstantesPae.EnConstruccion,
                        PAE_VIGENCIA = valueIndex,
                        PAE_NECE_YA_IMPORTADA = ConstantesPae.NoImportada,

                        PAE_IP_CREA = usuario.IpUsuario,
                        PAE_USU_CREA = usuario.UsuarioName,
                        PAE_MAQUINA_CREA = usuario.MachineName,
                        PAE_FECHA_CREA = usuario.Fecha,

                        PAE_IP_MOD = usuario.IpUsuario,
                        PAE_USU_MOD = usuario.UsuarioName,
                        PAE_MAQUINA_MOD = usuario.MachineName,
                        PAE_FECHA_MOD = usuario.Fecha

                    };

                    dbEntity.SIEDU_PAE
                        .Add(PAE);

                    dbEntity.SaveChanges();

                }
            }
            catch (DbEntityValidationException e)
            {
                Layers.Application.ExceptionUtility.LogException(e, "no se");
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        protected void btnGenerarPAE_Click(object sender, EventArgs e)
        {
            btnGuardarVigenciaPae.CommandName = "GenerarPae";
            OpenModalDatosDocumentos();
        }
    }
}