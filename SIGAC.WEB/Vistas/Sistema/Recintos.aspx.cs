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
            if (!IsPostBack)
            {
                FillGrid();
            }

        }

        private void FillGrid()
        {
            if (!gridViewRecintos.AllowPaging)
                gridViewRecintos.AllowPaging = true;
            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                var datosRecintos = dbContext.RECINTOS
                    //.Where(x => x.ESTATUS == 1)
                    .ToList();
                RefreshGridDataSource(datosRecintos, "Recintos Fill Grid Method");

            }
        }

        private void RefreshGridDataSource(List<Layers.Bussiness.Model.RECINTOS> datasource, string source)
            
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
            if (gridViewRecintos.AllowPaging)
                gridViewRecintos.AllowPaging = false;

            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                string texto = txtFiltro.Text.Trim();
                var resultados = dbContext.RECINTOS
                    .Where(x => x.NOMBRE.Contains(texto)).ToList();

                RefreshGridDataSource(resultados, "Recintos resultados de busqueda");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            txtNombre.Text = string.Empty;
            txtDir.Text = string.Empty;
            txtTel1.Text = string.Empty;
            txtTel2.Text = string.Empty;
            txtNotas.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
            Response.Redirect(Request.RawUrl);
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbContext = new Layers.Bussiness.Model.SigacEntities())
                {
                    try
                    {
                        dbContext.RECINTOS.Add(PrepareModel());
                        dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        Layers.Application.ExceptionUtility.LogException(ex, "Recintos V");
                    }
                    FillGrid();
                }
            }
        }

        private Layers.Bussiness.Model.RECINTOS PrepareModel()
        {
            string nombre = txtNombre.Text;
            string dir = txtDir.Text;
            string tel1 = txtTel1.Text;
            string tel2 = txtTel2.Text;
            var notas = new byte[16];//Convert.FromBase64String(txtNotas.Text.Trim().ToString());
            int estado = int.Parse(ddlEstado.SelectedItem.Value);

            Layers.Bussiness.Model.RECINTOS recinto = new Layers.Bussiness.Model.RECINTOS()
            {
                NOMBRE = nombre,
                DIRECCION = dir,
                TELEFONO1 = tel1,
                TELEFONO2 = tel2,
                NOTA = notas,
                ESTATUS = estado,
            };

            return recinto;
        }

        protected void gridViewRecintos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridViewRecintos.Rows[e.RowIndex];
            int argId = Convert.ToInt32(gridViewRecintos.DataKeys[e.RowIndex].Values[0]);
            string nombre = (row.FindControl("e_txtNombre") as TextBox).Text;
            string dir = (row.FindControl("e_txtDir") as TextBox).Text;
            string tel1 = (row.FindControl("e_txtTel1") as TextBox).Text;
            string tel2 = (row.FindControl("e_txtTel2") as TextBox).Text;
            var notas = new byte[16];//Convert.FromBase64String(txtNotas.Text.Trim().ToString());
            int estado = int.Parse(  (row.FindControl("e_ddlEstado") as DropDownList).SelectedItem.Value  );
            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                try
                {
                    var recinto = dbContext.RECINTOS
                                    .Where(x => x.ID == argId).FirstOrDefault();
                    recinto.NOMBRE = nombre;
                    recinto.DIRECCION = dir;
                    recinto.TELEFONO1 = tel1;
                    recinto.TELEFONO2 = tel2;
                    recinto.NOTA = notas;
                    recinto.ESTATUS = estado;
                    dbContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    Layers.Application.ExceptionUtility.LogException(ex, "Editando la data");
                }
            }
            gridViewRecintos.EditIndex = -1;
            FillGrid();

        }

        protected void gridViewRecintos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewRecintos.EditIndex = e.NewEditIndex;
            FillGrid();
        }
        

        protected void gridViewRecintos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillGrid();
            gridViewRecintos.PageIndex = e.NewPageIndex;
            gridViewRecintos.DataBind();
        }
        

        protected void gridViewRecintos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int argId = Convert.ToInt32(gridViewRecintos.DataKeys[e.RowIndex].Values[0]);
            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                try
                {
                    var recinto = dbContext.RECINTOS
                                    .Where(x => x.ID == argId).FirstOrDefault();
                    recinto.ESTATUS = 0;
                    dbContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    Layers.Application.ExceptionUtility.LogException(ex, "Eliminando la data");
                }
            }
            FillGrid();

        }

        protected void gridViewRecintos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewRecintos.EditIndex = -1;
            FillGrid();
        }

        protected void gridViewRecintos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridViewRecintos.EditIndex)
            {
                (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Desea Eliminar este registro');";
            }
        }
    }
}