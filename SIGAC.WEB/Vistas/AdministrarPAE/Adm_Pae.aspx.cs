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
                var Years = dbEntity.SIEDU_DOMINIO
                .GroupBy(x => x.VIGENTE)
                .Select(name => name.FirstOrDefault().VIGENTE)
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

            ScriptManager.RegisterStartupScript(this, GetType(), "none", "OpenModal('idModal') ;", true);

        }
    }
}