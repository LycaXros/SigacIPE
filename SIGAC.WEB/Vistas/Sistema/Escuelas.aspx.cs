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
                var datosEscuelas = dbContext.ESCUELA
                    .Where(x => x.ESTATUS == "Activo")
                    .ToList();
              

                RefreshGridDataSource(datosEscuelas, "Escuelas Fill Grid Method");

            }
        }

        private void RefreshGridDataSource(List<Layers.Bussiness.Model.ESCUELA> datasource, string source)
            
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
                var resultados = dbContext.ESCUELA
                    .Where(x => x.NOMBRE.Contains(texto) && x.ESTATUS == "Activo").ToList();

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
            txtDescripcion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtresponsable.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTel1.Text = string.Empty;
            txtTel2.Text = string.Empty;
            txtNotas.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
            comboboxRecintos.SelectedIndex = 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbContext = new Layers.Bussiness.Model.SigacEntities())
                {
                    try
                    {
                        dbContext.ESCUELA.Add(PrepareModel());
                        dbContext.SaveChanges();
                        CleanForm();
                    }
                    catch (Exception ex)
                    {

                        Layers.Application.ExceptionUtility.LogException(ex, "Escuela V");
                    }
                    FillGrid();
                }
            }
        }

        private Layers.Bussiness.Model.ESCUELA PrepareModel()
        {
            string nombre = txtNombre.Text;
            string Email = txtEmail.Text;
            string tel1 = txtTel1.Text;
            string tel2 = txtTel2.Text;

            var descripcion = Layers.Application.DataTransformUtility.StringToByte(txtDescripcion.Text, System.Text.Encoding.ASCII);
            string Responsable = txtresponsable.Text;
            string Estado = ddlEstado.SelectedValue;
            string recintos = comboboxRecintos.SelectedValue;


          


            var notas = //Convert.FromBase64String(txtNotas.Text.Trim().ToString());
                Layers.Application.DataTransformUtility.StringToByte(txtNotas.Text.Trim().ToString(), System.Text.Encoding.ASCII);
            int estado = int.Parse(ddlEstado.SelectedItem.Value);

            Layers.Bussiness.Model.ESCUELA escuela = new Layers.Bussiness.Model.ESCUELA()
            {
                ID_RECINTO = Convert.ToInt32(recintos),
                NOMBRE = nombre,
                DESCRIPCION = descripcion,
                EMAIL = Email,
                TELEFONO = tel1,
                TELEFONO2 = tel2,
                NOTA = notas,
                ESTATUS = Estado,
                RESPONSABLE = Responsable
            };

            return escuela;
        }

        protected void gridViewRecintos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridViewEcuelas.Rows[e.RowIndex];
            int argId = Convert.ToInt32(gridViewEcuelas.DataKeys[e.RowIndex].Values[0]);
            string ID_RECINTO = (row.FindControl("e_comboboxRecintos") as TextBox).Text;
            string nombre = (row.FindControl("e_txtNombre") as TextBox).Text;
            string DESCRIPCION = (row.FindControl("e_txtDescripcion") as TextBox).Text;
            string EMAIL = (row.FindControl("e_txtEmail") as TextBox).Text;
            string ESTATUS = (row.FindControl("e_ddlEstado") as TextBox).Text;
            string RESPONSABLE = (row.FindControl("e_txtresponsable") as TextBox).Text;
            string tel1 = (row.FindControl("e_txtTel1") as TextBox).Text;
            string tel2 = (row.FindControl("e_txtTel2") as TextBox).Text;

            var notas = //new byte[16]; Convert.FromBase64String(txtNotas.Text.Trim().ToString());
              Layers.Application.DataTransformUtility.StringToByte((row.FindControl("e_txtNotas") as TextBox).Text.Trim().ToString(), System.Text.Encoding.ASCII);

            var descripcion = //new byte[16]; Convert.FromBase64String(txtNotas.Text.Trim().ToString());
                Layers.Application.DataTransformUtility.StringToByte((row.FindControl("e_txtNotas") as TextBox).Text.Trim().ToString(), System.Text.Encoding.ASCII);
            int estado = int.Parse(  (row.FindControl("e_ddlEstado") as DropDownList).SelectedItem.Value  );
            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                try
                {
                    var escuela = dbContext.ESCUELA
                                    .Where(x => x.ID == argId).FirstOrDefault();
                    escuela.NOMBRE = nombre;
                    escuela.DESCRIPCION = descripcion;
                    escuela.TELEFONO = tel1;
                    escuela.TELEFONO2 = tel2;
                    escuela.NOTA = notas;
                    escuela.ESTATUS = ddlEstado.SelectedValue;
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
                    var recinto = dbContext.ESCUELA
                                    .Where(x => x.ID == argId).First();
                    recinto.ESTATUS = "Activo";
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