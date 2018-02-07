using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Bussiness.Model;
using SIGAC.Layers.Application;
using SIGAC.Layers.Data;
using System.Collections;

namespace SIGAC.WEB.Vistas.Sistema
{
    public partial class Cursos : System.Web.UI.Page
    {
        SiathEntities SIATH = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            fillGrid();
        }

        #region     Metodo para llenar el formulario con todos los registros encontrados

        /// <summary>
        /// Metodo para llenar el formulario con todos los registros encontrados
        /// </summary>
        private void fillGrid()
        {
            using (SIATH = new SiathEntities())
            {
                var Datos = SIATH.SIGAC_CURSOS.ToList();
                RefreshGridDataSource(Datos, "Cursos Fill Grid Method");
            }
        }

        #endregion  Metodo para llenar el formulario con todos los registros encontrados


        #region    Busqueda de cursos por Descripcion

        /// <summary>
        /// Busqueda de cursos por Descripcion
        /// </summary>
        private void searchCursoByDescripcion()
        {
            using (SIATH = new SiathEntities())
            {
                string texto = textboxFiltro.Text.Trim().ToLower();
                var Datos = SIATH.SIGAC_CURSOS
                    .Where(x => x.DESCRIPCION.ToLower().Contains(texto))
                    .ToList();

                RefreshGridDataSource(Datos, "Cursos Search Event");
            }
        }

        #endregion Busqueda de cursos por Descripcion


        #region     Refrescar el grid con la informacion que necesite

        /// <summary>
        /// Refrescar el grid con la informacion que necesite
        /// </summary>
        /// <param name="dataSource">Fuente de la informacion</param>
        /// <param name="source">Lugar en donde se realiza la accion de refrescar</param>
        private void RefreshGridDataSource(IEnumerable dataSource, string source)
        {
            try
            {
                gridViewCursos.DataSource = dataSource;
                gridViewCursos.DataBind();
            }
            catch (Exception ex)
            {

                ExceptionUtility.LogException(ex, source);
            }
        }

        #endregion  Refrescar el grid con la informacion que necesite


        protected void buttonFiltro_Click(object sender, EventArgs e)
        {
            searchCursoByDescripcion();
        }

        protected void gridViewCursos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Si no tiene nada ingresado en el textbox de busqueda, llena al grid con todos los registros
            //Si no, llena el grid con los datos de la busqueda.
            if (string.IsNullOrWhiteSpace(textboxFiltro.Text))
                fillGrid();
            else
                searchCursoByDescripcion();

            gridViewCursos.PageIndex = e.NewPageIndex;
            gridViewCursos.DataBind();
        }

        protected void gridViewCursos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridViewCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}