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
using SIGAC.Layers.Application;

namespace SIGAC.WEB.Vistas.AdministrarPAE
{
    public partial class Coberturas : System.Web.UI.Page
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
                ddlEstrategia.Items.Insert(0, new ListItem("Seleccione","-1"));



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
                    )
                    .ToList()
                    .Join(dbEntity.SIEDU_PAE, nom => nom, pae => pae.PAE_VIGENCIA,
                    (nom, pae) => new { Nombre = nom, ID_PAE = pae.PAE_PAE})
                    .ToList();

                ddlVigencia.DataTextField = "Nombre";
                ddlVigencia.DataValueField = "ID_PAE";
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
                
                ddlEscuela.DataValueField = "ID";
                ddlEscuela.DataTextField = "Nombre";
                ddlEscuela.DataSource = query;
                ddlEscuela.DataBind();
                ddlEscuela.Items.Insert(0, new ListItem("Seleccione", "-1"));

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string vigencia = ddlVigencia.SelectedValue;
            CallGrid();
            //llenagrid(Convert.ToInt32(vigencia));

        }

        private void CallGrid()
        {
            short estrategia =  short.Parse(ddlEstrategia.SelectedItem.Value);
            short escuela =     short.Parse(ddlEscuela.SelectedItem.Value);

            if (estrategia.Equals(-1) || escuela.Equals(-1))
            {
                LlenarGrid();
            }
            else
            {
                LlenarGrid(escuela, estrategia);
            }
        }

        private void LlenarGrid(short escuela = 0, short estrategia = 0)
        {
            int vigencia = int.Parse(ddlVigencia.SelectedItem.Value);
            try
            {
                using (dbEntity = new SigacEntities())
                {

                    IList query = null;
                    if ( escuela == 0 || estrategia == 0)
                    {
                        query =(
                            from coberturas in dbEntity.SIEDU_COBERTURA 
                            join esc in dbEntity.ESCUELA on coberturas.COBE_UDE_ESCU equals esc.ID
                            join estra in dbEntity.SIEDU_DOMINIO on coberturas.COBE_DOM_ESTRA equals estra.ID_DOMINIO
                            where coberturas.COBE_PAE.Equals(vigencia)
                            select new
                            {
                                DataRowID = coberturas.COBE_COBE,
                                EscuelaName = esc.NOMBRE,
                                UnidadName = coberturas.COBE_UDE_UFISI,
                                EstrategiaName = estra.NOMBRE
                            }
                            
                            ).ToList();
                        
                    }
                    else
                    {
                        query = (
                            from coberturas in dbEntity.SIEDU_COBERTURA
                            join esc in dbEntity.ESCUELA on coberturas.COBE_UDE_ESCU equals esc.ID
                            join estra in dbEntity.SIEDU_DOMINIO on coberturas.COBE_DOM_ESTRA equals estra.ID_DOMINIO
                            where coberturas.COBE_PAE.Equals(vigencia)
                                && estra.ID_DOMINIO.Equals(estrategia)
                                && esc.ID.Equals(escuela)
                            select new
                            {
                                DataRowID = coberturas.COBE_COBE,
                                EscuelaName = esc.NOMBRE,
                                UnidadName = coberturas.COBE_UDE_UFISI,
                                EstrategiaName = estra.NOMBRE
                            }

                            ).ToList();
                    }

                    RefreshGridDataSource(query, "covertura Fill Grid Method");
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Llenando los datos del grid");
            }
        }

        private void llenagrid(int vigencia)
        {

            using (dbEntity = new SigacEntities())
            {
                var SIEDU_COBERTURA = dbEntity.SIEDU_COBERTURA
                     .Where(z => z.COBE_PAE == vigencia)
                     .OrderBy(x => x.COBE_COBE)
                     .OrderBy(X => X.COBE_UDE_ESCU)
                     .ToList();

                
                RefreshGridDataSource(SIEDU_COBERTURA, "covertura Fill Grid Method");

            }
        }


        private void RefreshGridDataSource(IEnumerable dataSource, string source)
        {
            try
            {
                gv_menu.DataSource = dataSource;
                gv_menu.DataBind();
            }
            catch (Exception ex)
            {

                ExceptionUtility.LogException(ex, source);
            }
        }

        protected void gv_menu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowID = Convert.ToInt32(gv_menu.DataKeys[e.RowIndex].Values[0]);
            using (dbEntity = new SigacEntities())
            {
                var cobertura = dbEntity.SIEDU_COBERTURA
                    .First(x => x.COBE_COBE.Equals(rowID));
                dbEntity.SIEDU_COBERTURA.Remove(cobertura);
                dbEntity.SaveChanges();
                
            }
            CallGrid();
        }

        protected void gv_menu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gv_menu.EditIndex)
            {
                (e.Row.Cells[4].Controls[1] as LinkButton).Attributes["onclick"] = "return confirm('Desea Eliminar este registro?');";
            }
        }


        // bool validar(dynamic x) => x.COBE_PAE == vigencia;
    }
}