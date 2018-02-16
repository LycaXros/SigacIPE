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
                FillGrid();
                llenapae();
                llenaescuela();
            }

        }

        private void FillGrid()
        {
            using (dbEntity = new SigacEntities())
            {
                var query =
                   (from dominio in dbEntity.SIEDU_DOMINIO
                    join tipoDominio in dbEntity.SIEDU_TIPO_DOMINIO on dominio.ID_TIPO_DOMINIO equals tipoDominio.ID_TIPO_DOMINIO
                    where tipoDominio.NOMBRE == "ESTRATEGIA"
                    select dominio).ToList();

                var query2 =
                    dbEntity.SIEDU_DOMINIO
                    .Join(dbEntity.SIEDU_TIPO_DOMINIO,
                        dom => dom.ID_TIPO_DOMINIO,
                        type => type.ID_TIPO_DOMINIO,
                        (dom, type) => new { Dominio = dom, Tipo = type })
                        .Where(x => x.Tipo.NOMBRE == "ESTRATEGIA")
                        .Select(x => x.Dominio)
                        .Distinct()
                        .ToList();

                ddlEstrategia.DataValueField = "ID_Dominio";
                ddlEstrategia.DataTextField = "NOMBRE";
                ddlEstrategia.DataSource = query;
                ddlEstrategia.DataBind();


            }
        }

        private void llenapae()
        {

            using (dbEntity = new SigacEntities())
            {
                var query =
                   (from SIEDU_PAE in dbEntity.SIEDU_PAE
                    where SIEDU_PAE.PAE_PAE > 0
                    select SIEDU_PAE).ToList();

                ddlpae.DataValueField = "PAE_PAE";
                ddlpae.DataTextField = "PAE_VIGENCIA";
                ddlpae.DataSource = query;
                ddlpae.DataBind();



            }



        }
        private void llenaescuela()
        {
            using (dbEntity = new SigacEntities())
            {

                var query =
                (from ESCUELA in dbEntity.ESCUELA
                 where ESCUELA.ESTATUS == "Activo"
                 select ESCUELA).ToList();

                ddlEscuela.DataValueField = "ID";
                ddlEscuela.DataTextField = "NOMBRE";
                ddlEscuela.DataSource = query;
                ddlEscuela.DataBind();

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            llenagrid(ddlpae.SelectedIndex);

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