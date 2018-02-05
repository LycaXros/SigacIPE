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
            ButtonEnabling(false);
        }

        private void FillGrid()
        {
            using (dbContext = new Layers.Bussiness.Model.SigacEntities())
            {
                var datosRecintos = dbContext.RECINTOS
                    //.Where(x => x.ESTATUS == 1)
                    .ToList();
                RefreshGridDataSource(datosRecintos, "Recintos Fill Grid Method");

            }
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
                .Where(x => x.NOMBRE.Contains(texto)).ToList();

            RefreshGridDataSource(resultados, "Recintos resultados de busqueda");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ButtonEnabling(false);

            txtNombre.Text = string.Empty;
            txtDir.Text = string.Empty;
            txtTel1.Text = string.Empty;
            txtTel2.Text = string.Empty;
            txtNotas.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
            Response.Redirect(Request.RawUrl);
        }

        protected void accionBtn_Click(object sender, EventArgs e)
        {
            string Name = (sender as LinkButton).CommandName;
            string Argument = (sender as LinkButton).CommandArgument;

            switch (Name)
            {
                case "Edit":
                    EditData(Argument);
                    break;
                case "Delete":
                    DeleteData(Argument);
                    break;
                default:
                    Layers.Application.ExceptionUtility.LogException(new Exception(), "Comando no correcto");
                    break;
            }
        }

        private void DeleteData(string argument)
        {
            var recinto = dbContext.RECINTOS
                .Where(x => x.ID.ToString() == argument).FirstOrDefault();
            recinto.ESTATUS = 0;
            dbContext.SaveChanges();
        }

        private void EditData(string argument)
        {
            var recinto = dbContext.RECINTOS
                .Where(x => x.ID.ToString() == argument).FirstOrDefault();
            txtNombre.Text = recinto.NOMBRE;
            txtDir.Text = recinto.DIRECCION;
            txtTel1.Text = recinto.TELEFONO1;
            txtTel2.Text = recinto.TELEFONO2;
            txtNotas.Text = Convert.ToBase64String(recinto.NOTA);
            ddlEstado.SelectedValue = recinto.ESTATUS.ToString();

            btnModificar.CommandArgument = argument;
            ButtonEnabling(true);

        }

        private void ButtonEnabling(bool val)
        {
            btnAgregar.Visible = !val;
            btnModificar.Visible = val;
            btnCancelar.Visible = val;

            btnAgregar.Enabled = !val;
            btnModificar.Enabled = val;
            btnCancelar.Enabled = val;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                dbContext = new Layers.Bussiness.Model.SigacEntities();
                string Name = (sender as IButtonControl).CommandName;
                string argument = (sender as IButtonControl).CommandArgument;

                string nombre = txtNombre.Text;
                string dir = txtDir.Text;
                string tel1 = txtTel1.Text;
                string tel2 = txtTel2.Text;
                var notas = new byte[16];//Convert.FromBase64String(txtNotas.Text.Trim().ToString());
                int estado = int.Parse( ddlEstado.SelectedItem.Value);
                try
                {
                    if (Name.CompareTo("Add") == 0)
                    {
                        Layers.Bussiness.Model.RECINTOS r = new Layers.Bussiness.Model.RECINTOS()
                        {
                            NOMBRE = nombre,
                            DIRECCION = dir,
                            TELEFONO1 = tel1,
                            TELEFONO2 = tel2,
                            NOTA = notas,
                            ESTATUS = estado
                        };
                        dbContext.RECINTOS.Add(r);


                    }
                    else if (Name.CompareTo("Mod") == 0)
                    {
                        var r = dbContext.RECINTOS
                            .Where(x => x.ID.ToString() == argument).FirstOrDefault();
                        r.NOMBRE = nombre;
                        r.DIRECCION = dir;
                        r.TELEFONO1 = tel1;
                        r.TELEFONO2 = tel2;
                        r.NOTA = notas;
                        r.ESTATUS = estado;
                    }
                    dbContext.SaveChanges();

                }
                catch (Exception ex)
                {

                    Layers.Application.ExceptionUtility.LogException(ex, "Recintos V");
                }
                ButtonEnabling(false);
                FillGrid();
            }
        }
    }
}