using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIGAC.WEB.Vistas.Sistema
{
    public partial class Escuelas : System.Web.UI.Page
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
            if (!gridViewEcuelas.AllowPaging)
                gridViewEcuelas.AllowPaging = true;
            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                var datosRecintos = dbContext.RECINTOS
                    .Where(x => x.ESTATUS == 1)
                    .ToList();
                RefreshGridDataSource(datosRecintos, "Escuelas Fill Grid Method");

            }
        }

        private void RefreshGridDataSource(List<Layers.Bussiness.Model.RECINTOS> datasource, string source)
            
        {
            try
            {
                datasource = datasource.OrderBy(x => x.ID).ToList();
                gridViewEcuelas.DataSource = datasource;
                gridViewEcuelas.DataBind();
            }
            catch (Exception ex)
            {

                Layers.Application.ExceptionUtility.LogException(ex, source);
            }
        }

        protected void buttonFiltro_Click(object sender, EventArgs e)
        {
            if (gridViewEcuelas.AllowPaging)
                gridViewEcuelas.AllowPaging = false;

            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                string texto = txtFiltro.Text.Trim();
                var resultados = dbContext.RECINTOS
                    .Where(x => x.NOMBRE.Contains(texto) && x.ESTATUS == 1).ToList();

                RefreshGridDataSource(resultados, "Recintos resultados de busqueda");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanForm();
            Response.Redirect(Request.RawUrl);
        }

        private void CleanForm()
        {
            txtNombre.Text = string.Empty;
            txtDir.Text = string.Empty;
            txtTel1.Text = string.Empty;
            txtTel2.Text = string.Empty;
            txtNotas.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
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
                        CleanForm();
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
            var notas = //Convert.FromBase64String(txtNotas.Text.Trim().ToString());
                Layers.Application.DataTransformUtility.StringToByte(txtNotas.Text.Trim().ToString(), System.Text.Encoding.ASCII);
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
            GridViewRow row = gridViewEcuelas.Rows[e.RowIndex];
            int argId = Convert.ToInt32(gridViewEcuelas.DataKeys[e.RowIndex].Values[0]);
            string nombre = (row.FindControl("e_txtNombre") as TextBox).Text;
            string dir = (row.FindControl("e_txtDir") as TextBox).Text;
            string tel1 = (row.FindControl("e_txtTel1") as TextBox).Text;
            string tel2 = (row.FindControl("e_txtTel2") as TextBox).Text;
            var notas = //new byte[16]; Convert.FromBase64String(txtNotas.Text.Trim().ToString());
                Layers.Application.DataTransformUtility.StringToByte((row.FindControl("e_txtNotas") as TextBox).Text.Trim().ToString(), System.Text.Encoding.ASCII);
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
            gridViewEcuelas.EditIndex = -1;
            FillGrid();

        }

        protected void gridViewRecintos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewEcuelas.EditIndex = e.NewEditIndex;
            FillGrid();
        }
        

        protected void gridViewRecintos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillGrid();
            gridViewEcuelas.PageIndex = e.NewPageIndex;
            gridViewEcuelas.DataBind();
        }
        

        protected void gridViewRecintos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int argId = Convert.ToInt32(gridViewEcuelas.DataKeys[e.RowIndex].Values[0]);
            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                try
                {
                    var recinto = dbContext.RECINTOS
                                    .Where(x => x.ID == argId).First();
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
            gridViewEcuelas.EditIndex = -1;
            FillGrid();
        }

        protected void gridViewRecintos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridViewEcuelas.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Desea Eliminar este registro');";
            }
        }
    }
}