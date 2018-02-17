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

namespace SIGAC.WEB.Vistas.AdministrarPAE
{
    public partial class coverturas : System.Web.UI.Page
    {
        Layers.Bussiness.Model.SigacEntities dbEntity = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDdlEstrategias();
                LlenarDdlVigencia();
                LlenarDdlEscuelas();
            }

        }

        private void LlenarDdlEstrategias()
        {
            using (dbEntity = new SigacEntities())
            {
                var query =
                   (from dominio in dbEntity.SIEDU_DOMINIO
                    join tipoDominio in dbEntity.SIEDU_TIPO_DOMINIO on dominio.ID_TIPO_DOMINIO equals tipoDominio.ID_TIPO_DOMINIO
                    where tipoDominio.NOMBRE == "ESTRATEGIA"
                    orderby tipoDominio.NOMBRE descending
                    select new
                    {
                        ID = dominio.ID_DOMINIO,
                        Nombre = dominio.NOMBRE
                    }
                    ).ToList();
                query.Add(new
                {
                    ID = (short)-1,
                    Nombre = "Seleccione"
                });

                //var query2 =
                //    dbEntity.SIEDU_DOMINIO
                //    .Join(dbEntity.SIEDU_TIPO_DOMINIO,
                //        dom => dom.ID_TIPO_DOMINIO,
                //        type => type.ID_TIPO_DOMINIO,
                //        (dom, type) => new { Dominio = dom, Tipo = type })
                //        .Where(x => x.Tipo.NOMBRE == "ESTRATEGIA")
                //        .Select(x => x.Dominio)
                //        .Distinct()
                //        .ToList();

                ddlEstrategia.DataValueField = "ID";
                ddlEstrategia.DataTextField = "Nombre";
                ddlEstrategia.DataSource = query;
                ddlEstrategia.DataBind();
                ddlEstrategia.SelectedValue = ddlEstrategia.Items.FindByValue("-1").Value;



            }
        }

        private void LlenarDdlVigencia()
        {

            using (dbEntity = new SigacEntities())
            {
                var query =
                   (from dominio in dbEntity.SIEDU_DOMINIO
                    join tipoDominio in dbEntity.SIEDU_TIPO_DOMINIO on dominio.ID_TIPO_DOMINIO equals tipoDominio.ID_TIPO_DOMINIO
                    where tipoDominio.NOMBRE == "VIGENCIA"
                    orderby tipoDominio.NOMBRE descending
                    select dominio.NOMBRE
                    ).ToList();

                ddlVigencia.DataSource = query;
                ddlVigencia.DataBind();

            }



        }
        private void LlenarDdlEscuelas()
        {
            using (dbEntity = new SigacEntities())
            {

                var query =
                (from ESCUELA in dbEntity.ESCUELA
                 where ESCUELA.ESTATUS == "Activo"
                 select new
                 {
                     ID = ESCUELA.ID,
                     Nombre = ESCUELA.NOMBRE
                 }).ToList();

                query.Add(
                    new {
                        ID = -1m,
                        Nombre = "Seleccione"
                    });

                ddlEscuela.DataValueField = "ID";
                ddlEscuela.DataTextField = "Nombre";
                ddlEscuela.DataSource = query;
                ddlEscuela.DataBind();
                ddlEscuela.SelectedValue = ddlEscuela.Items.FindByValue("-1").Value;

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string estrategia = ddlEstrategia.SelectedItem.Value;
            string escuela = ddlEscuela.SelectedItem.Value;

            if (estrategia.Equals("-1") || escuela.Equals("-1"))
            {
                LlenarGrid();
            }
            else
            {
                LlenarGrid(escuela, estrategia);
            }
            //llenagrid(ddlpae.SelectedIndex);

        }

        private void LlenarGrid(string escuela = "", string estrategia = "")
        {
            string vigencia = ddlVigencia.SelectedItem.Value; try
            {
                using (dbEntity = new SigacEntities())
                {

                    IList query = null;
                    if (string.IsNullOrEmpty(escuela) && string.IsNullOrEmpty(estrategia))
                    {
                        query = dbEntity.SIEDU_COBERTURA.ToList();
                    } 
                }
            }
            catch (Exception ex)
            {
                Layers.Application.ExceptionUtility.LogException(ex, "Llenando los datos del grid");
            }
        }

        private void llenagrid(int vigencia)
            {

            using (dbEntity = new SigacEntities())
            {
                var SIEDU_COBERTURA = dbEntity.SIEDU_COBERTURA
                     .Select(y => y)
                     .Where(z => z.COBE_PAE == vigencia)
                     .OrderBy(x => x.COBE_COBE)
                     .OrderBy(X => X.COBE_UDE_ESCU)
                     .ToList();

              //RefreshGridDataSource(SIEDU_COBERTURA, "Aulas Fill Grid Method");

            }
        }
    }
}