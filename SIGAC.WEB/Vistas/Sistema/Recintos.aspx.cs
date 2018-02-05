using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIGAC.WEB.Vistas.Sistema
{
    public partial class Recintos : System.Web.UI.Page
    {
        Layers.Bussiness.Model.SigacEntities dbContext = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //    return;
            dbContext = new Layers.Bussiness.Model.SigacEntities();
            FillGrid();
        }

        private void FillGrid()
        {
            var datosRecintos = dbContext.RECINTOS
                .Where(x=> x.ESTATUS == 1 )
                .ToList();
            RefreshGridDataSource(datosRecintos, "Recintos Fill Grid Method");
        }

        private void RefreshGridDataSource(IEnumerable datasource, string source)
        {
            try
            {
                gridViewRecintos.DataSource = datasource;
                gridViewRecintos.DataBind();
            }
            catch (Exception ex)
            {

                Layers.Application.ExceptionUtility.LogException(ex, source);
            }
        }

        protected void buttonFiltro_Click(object sender, EventArgs e)
        {
            string texto = txtFiltro.Text.Trim();
            var resultados = dbContext.RECINTOS
                .Where(x => x.NOMBRE.Contains(texto) ).ToList();

            RefreshGridDataSource(resultados, "Recintos resultados de busqueda");

        }
    }
}