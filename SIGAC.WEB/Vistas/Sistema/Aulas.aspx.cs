using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Application;
using SIGAC.Layers.Data;
using SIGAC.Layers.Bussiness.Model;
using SIGAC.Layers;
using System.Collections;

namespace SIGAC.WEB.Vistas.Sistema
{
    public partial class Aulas : System.Web.UI.Page
    {
        SigacEntities SIGACEntities = null;
        SiathEntities SIATHEntities = null;

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

        protected void gridViewAsignaturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            int commandArgument = int.Parse(e.CommandArgument.ToString());

            switch (commandName)
            {
                case "Editar":
                    {
                      //  Response.Redirect(GlobalVariables.ServerUrl + "Sistema/Asignaturas/" + commandArgument);
                        break;
                    }
                case "Eliminar":
                    {
                      //  deleteAsignatura(commandArgument);
                        break;
                    }
            }
        }

        //private ASIGNATURAS prepareModel()
        //{
        //    ASIGNATURAS asignatura = new ASIGNATURAS()
        //    {
        //        CURSOS =,
        //        NOMBRE =,
        //        DESCRIPCION =,
        //        CONTENIDO =,
        //        CREDITOS =,
        //        HORAS =,
        //        FECHA_INICIO =,
        //        FECHA_FIN =,
        //        OBSERVACION =,
        //        TIPO =,
        //        HORARIO1 =,
        //        HORA1 =,
        //        HORARIO2 =,
        //        HORA2 = ,
        //        ESTATUS =,
        //    };

        //    return asignatura;
        //}

        private void deleteAsignatura(int commandArgument)
        {
            try
            {
                using (SIGACEntities = new SigacEntities())
                {
                    var DeleteItem = SIGACEntities.ASIGNATURAS.Where(x => x.ID == commandArgument).First();
                    DeleteItem.ESTATUS = 0;

                    SIGACEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Asignaturas Eliminar Command");
            }
        }

        private void searchAsignaturaByNameOrCourseName()
        {

            using (SIGACEntities = new SigacEntities())
            {

                var search = SIGACEntities.ASIGNATURAS
                    .Where(x => (x.NOMBRE.ToLower().Contains(textboxFiltro.Text.ToLower())
                    || x.CURSOS.ToString().ToLower().Contains(textboxFiltro.Text.ToLower())
                    && x.ESTATUS != 0))
                    .OrderBy(y => y.FECHA_INICIO)
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
                     .Where(z => z.ESTATUS != 0)
                     .OrderBy(x => x.FECHA_INICIO)
                     .ToList();

                RefreshGridDataSource(Asignaturas, "Asignaturas Fill Grid Method");

            }
        }



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




    }
}