using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Application;
using SIGAC.Layers.Data;
using SIGAC.Layers.Bussiness.Model;
using System.Collections;

namespace SIGAC.WEB.Vistas.Sistema
{
    public partial class Asignaturas : System.Web.UI.Page
    {
        SigacEntities SIGACEntities = null;
        //SiathEntities SIATHEntities = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            fillGridView();
            //fillDropDown();

        }

        protected void buttonFiltro_Click(object sender, EventArgs e)
        {
            if (textboxFiltro.Text.Length > 0)
                searchAsignaturaByNameOrCourseName();
            else
                fillGridView();
        }

        private void searchAsignaturaByNameOrCourseName()
        {

            using (SIGACEntities = new SigacEntities())
            {

                var search = SIGACEntities.ASIGNATURAS
                    .Where(x => x.NOMBRE.ToLower().Contains(textboxFiltro.Text.ToLower())
                    || x.CURSOS.ToString().ToLower().Contains(textboxFiltro.Text.ToLower()))
                    .ToList();

                RefreshGridDataSource(search, "Asignaturas Search Method");
            }


        }

        void fillGridView()
        {
            using (SIGACEntities = new SigacEntities())
            {
                var Asignaturas = SIGACEntities.ASIGNATURAS
                     .Select(y => y)
                     .OrderBy(x => x.ID)
                     .ToList();

                RefreshGridDataSource(Asignaturas, "Asignaturas Fill Grid Method");

            }
        }

        //void fillDropDown()
        //{
        //    using (SIATHEntities = new SiathEntities())
        //    {
        //        var cursos = SIATHEntities.SIGAC_CURSOS
        //            .Select(x => x)
        //            .ToList();

        //        KeyValuePair<string, string> fields = new KeyValuePair<string, string>("ID_CURSO", "DESCRIPCION");

        //        RefreshDropDownSource(cursos, selectCurso, fields, "Asignaturas Fill DropDown Method");
        //    }
        //}

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
                gridViewAsignaturas.DataSource = dataSource;
                gridViewAsignaturas.DataBind();
            }
            catch (Exception ex)
            {

                ExceptionUtility.LogException(ex, source);
            }
        }

        #endregion  Refrescar el grid con la informacion que necesite

        //#region     Refrescar un dropDownList con la informacion que necesite

        ///// <summary>
        ///// Refrescar un dropDownList con la informacion que necesite
        ///// </summary>
        ///// <param name="dataSource">Fuente de la informacion</param>
        ///// <param name="dropDownList">DropDown que se desea popular con informacion</param>
        ///// <param name="Fields">La Key es el Text Field, y el Value el Value Field</param>
        ///// <param name="source">Lugar en donde se realiza la accion de refrescar</param>
        //private void RefreshDropDownSource(IEnumerable dataSource, DropDownList dropDownList, KeyValuePair<string, string> Fields, string source)
        //{
        //    try
        //    {
        //        dropDownList.DataSource = dataSource;
        //        dropDownList.DataTextField = Fields.Value.ToString();
        //        dropDownList.DataValueField = Fields.Key.ToString();
        //        dropDownList.DataBind();
        //    }
        //    catch (Exception ex)
        //    {

        //        ExceptionUtility.LogException(ex, source);
        //    }
        //}

        //#endregion  Refrescar un dropDownList con la informacion que necesite



        protected void gridViewAsignaturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridViewAsignaturas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridViewAsignaturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textboxFiltro.Text))
                fillGridView();
            else
                searchAsignaturaByNameOrCourseName();

            gridViewAsignaturas.PageIndex = e.NewPageIndex;
            gridViewAsignaturas.DataBind();
        }
    }
}