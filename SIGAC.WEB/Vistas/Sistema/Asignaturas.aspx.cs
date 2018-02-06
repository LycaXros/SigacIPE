using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Application;
using SIGAC.Layers.Data;
using SIGAC.Layers.Bussiness.Model;

namespace SIGAC.WEB.Vistas.Sistema
{
    public partial class Asignaturas : System.Web.UI.Page
    {
        SigacEntities SIGACEntities = null;
        SiathEntities SIATHEntities = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

        }

        protected void buttonFiltro_Click(object sender, EventArgs e)
        {

        }

        void fillGridView()
        {
            using (SIGACEntities = new SigacEntities())
            {
                
            }
        }

        

        protected void gridViewAsignaturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridViewAsignaturas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridViewAsignaturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}