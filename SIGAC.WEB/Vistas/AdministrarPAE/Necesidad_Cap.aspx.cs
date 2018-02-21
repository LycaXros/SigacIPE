using System;
using System.Collections;
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
using System.Data.SqlClient;
using System.Data.Common;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;

namespace Sigac.WEB.Vistas.AdministrarPAE
{
    public partial class Necesidad_Cap : System.Web.UI.Page
    {
        #region variables a utilizar 

        /// <summary>
        /// Variable para almacenar el query que se desea correr 
        /// </summary>
        string stringSqlQuery;


        #endregion variables a utilizar 


        #region     Metodo Load de la Pagina de Asignaturas
        /// <summary>
        /// Metodo Load de la Pagina de Recintos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataNecesidadCapacitacion();
            fillComboBoxddlEscuelas();
            fillComboBoxddlModalidad();
            fillComboBoxddlPresupuesto();
            fillComboBoxddlVigencia();

        }
        #endregion  Metodo Load de la Pagina de Asignaturas


        #region     Metodo que te permite obtener los datos de la tabla Asignaturas para llenar el Web Grid View

        /// <summary>
        /// Metodo que te permite obtener los datos de la tabla Asignaturas para llenar el Web Grid View
        /// </summary>
        private void getDataNecesidadCapacitacion()
        {
            stringSqlQuery = "SELECT 'CAPA_UDE_ESCU', 'CAPA_DOM_PROCE', 'CAPA_DOM_ESTRA', 'CAPA_ID_CARRERA', 'CAPA_NRO_NECE', 'CAPA_ESTADO', 'CAPA_TOTAL_PERSONAS', 'CAPA_TOTAL_EVENTOS', 'CAPA_DOM_MODAL', 'CAPA_PPTO', 'CAPA_EVEN_T1', 'CAPA_PERS_T1', 'CAPA_EVEN_T2', 'CAPA_PERS_T2', 'CAPA_EVEN_T3', 'CAPA_PERS_T3', 'CAPA_EVEN_T4', 'CAPA_PERS_T4' FROM 'SIEDU_PAE_CAPACITACION' ";

            //gv_menu.DataSource = conseguirDataFromDatabase.getData(stringSqlQuery);
            //gv_menu.DataBind();

        }

        #endregion  Metodo que te permite obtener los datos de la tabla Asignaturas para llenar el Web Grid View


        #region     Evento Click del btnFuncionario, para buscar informacion en la base de datos



        #endregion  Evento Click del btnFuncionario, para buscar informacion en la base de datos


        #region     Llenar ComboBox desde Base de datos


        #region     ddlEscuela

        /// <summary>
        /// Llenar con datos de la base de datos los combobox
        /// </summary>
        private void fillComboBoxddlEscuelas()
        {
            stringSqlQuery = @"SELECT ID, NOMBRE FROM */*/";

            //ddlEscuela.DataSource = conseguirDataFromDatabase.getData(stringSqlQuery);
            //ddlEscuela.DataTextField = "NOMBRE";
            //ddlEscuela.DataValueField = "ID";

            //ddlEscuela.DataBind();
        }

        #endregion     ddlEscuela


        #region     ddlVigencia

        /// <summary>
        /// Llenar con datos de la base de datos los combobox
        /// </summary>
        private void fillComboBoxddlVigencia()
        {
            stringSqlQuery = @"SELECT ID, NOMBRE FROM */*/";

            //ddlVigencia.DataSource = conseguirDataFromDatabase.getData(stringSqlQuery);
            //ddlVigencia.DataTextField = "NOMBRE";
            //ddlVigencia.DataValueField = "ID";

            //ddlVigencia.DataBind();
        }

        #endregion     ddlVigencia


        #region     ddlModalidad

        /// <summary>
        /// Llenar con datos de la base de datos los combobox
        /// </summary>
        private void fillComboBoxddlModalidad()
        {
            stringSqlQuery = @"SELECT ID, NOMBRE FROM */*/";

            //ddlModalidad.DataSource = conseguirDataFromDatabase.getData(stringSqlQuery);
            //ddlModalidad.DataTextField = "NOMBRE";
            //ddlModalidad.DataValueField = "ID";

            //ddlModalidad.DataBind();
        }

        #endregion     ddlModalidad


        #region     ddlPresupuesto

        /// <summary>
        /// Llenar con datos de la base de datos los combobox
        /// </summary>
        private void fillComboBoxddlPresupuesto()
        {
            stringSqlQuery = @"SELECT ID, NOMBRE FROM */*/";

            //ddlPresupuesto.DataSource = conseguirDataFromDatabase.getData(stringSqlQuery);
            //ddlPresupuesto.DataTextField = "NOMBRE";
            //ddlPresupuesto.DataValueField = "ID";

            //ddlPresupuesto.DataBind();
        }

        #endregion     ddlPresupuesto


        #endregion  Llenar ComboBox desde Base de Datos
    }
}