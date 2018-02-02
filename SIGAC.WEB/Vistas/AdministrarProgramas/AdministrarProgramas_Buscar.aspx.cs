using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Bussiness.Model;

namespace SIGAC.WEB.Vistas.AdministrarProgramas
{
    public partial class AdministrarProgramas_Buscar : System.Web.UI.Page
    {
        private static Entities Entities = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Entities = new Entities();

                //var NivelAcademico = Entities.
            }
        }

        //private void fillSelect(DropDownList selectObject, List<object> List, string ValueField = null, string TextField = null)
        //{
        //    selectObject.DataSource = List;
        //    if (!string.IsNullOrWhiteSpace(ValueField))
        //        selectObject.DataValueField = ValueField;
        //    if (!string.IsNullOrWhiteSpace(ValueField))
        //        selectObject.DataTextField = TextField;

        //    selectObject.DataBind();
        //}


        #region    Grid View Administrar Programas

        protected void gridViewAdministrarProgramas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridViewAdministrarProgramas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridViewAdministrarProgramas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gridViewAdministrarProgramas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        #endregion Grid View Administrar Programas


        #region    Grid View Versiones

        protected void gridViewVersiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridViewVersiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridViewVersiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gridViewVersiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        #endregion Grid View Versiones
    }
}