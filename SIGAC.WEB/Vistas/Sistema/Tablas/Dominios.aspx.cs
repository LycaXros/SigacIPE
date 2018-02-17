using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Bussiness.Model;

namespace SIGAC.WEB.Vistas.Sistema.Tablas
{
    public partial class Dominios : System.Web.UI.Page
    {
        SigacEntities dbEntity = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            try
            {

                using (dbEntity = new SigacEntities())
                {
                    var query = (
                                from type in dbEntity.SIEDU_TIPO_DOMINIO
                                join doms in dbEntity.SIEDU_DOMINIO on type.ID_TIPO_DOMINIO equals doms.ID_TIPO_DOMINIO into typeWithDoms
                                select new
                                {
                                    Nom = type.NOMBRE,
                                    Desc = type.DESCRIPCION,
                                    Cant = typeWithDoms.Count(),
                                    ID = type.ID_TIPO_DOMINIO
                                }).ToList();

                    gridTipoDeDominio.DataSource = query;
                    gridTipoDeDominio.DataBind();


                }
            }
            catch (Exception ex)
            {
                Layers.Application.ExceptionUtility.LogException(ex, "LLenando el Grid");
            }
        }

        protected void BtnAgregarDominio_Click(object sender, EventArgs e)
        {
            var value = byte.Parse(Id_tipo.Value);
            string nombre = txtNombreDom.Text.Trim();
            string desc = txtDescDom.Text.Trim();
            string vigencia = txtVigenciaDom.Text.Trim();
            try
            {

                using (dbEntity = new SigacEntities())
                {
                    dbEntity.SIEDU_DOMINIO.Add(new SIEDU_DOMINIO()
                    {
                        ID_TIPO_DOMINIO = value,
                        NOMBRE = nombre,
                        DESCRIPCION = desc,
                        VIGENTE = vigencia
                    });
                    dbEntity.SaveChanges();
                    Response.RedirectToRoute("Sistema.Tablas.Dominios");
                }

            }
            catch (Exception ex)
            {
                Layers.Application.ExceptionUtility.LogException(ex, "Viendo listado de Dominos");
            }
        }

        protected void BtnAgregarTipoDominio_Click(object sender, EventArgs e)
        {
            string nombre = TxtNuevoTipo.Text.Trim().ToString();
            string descripcion = TxtDescripcionNuevo.Text.Trim().ToString();
            try
            {
                using (dbEntity = new SigacEntities())
                {
                    dbEntity.SIEDU_TIPO_DOMINIO.Add(
                        new SIEDU_TIPO_DOMINIO()
                        {

                            NOMBRE = nombre,
                            DESCRIPCION = descripcion
                        });
                    dbEntity.SaveChanges();
                    Response.RedirectToRoute("Sistema.Tablas.Dominios");
                }
            }
            catch (Exception ex)
            {
                Layers.Application.ExceptionUtility.LogException(ex, "Agregando tipo de Dominio");
            }
        }

        protected void gridTipoDeDominio_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comando = e.CommandName.ToString();
            var argumento = byte.Parse(e.CommandArgument.ToString());

            if (comando.Equals("Ver"))
            {
                try
                {

                    using (dbEntity = new SigacEntities())
                    {
                        var titulo = dbEntity.SIEDU_TIPO_DOMINIO.Where(x => x.ID_TIPO_DOMINIO == argumento).Select(x => x.NOMBRE).First();
                        var query =
                            dbEntity.SIEDU_DOMINIO
                            .Where(x => x.ID_TIPO_DOMINIO == argumento)
                            .OrderBy(x => x.ID_DOMINIO)
                            .ToList();
                        LabelTitle.Text = $"Presentando los Dominios del tipo '{titulo}'";
                        listadoDominos.DataSource = query;
                        listadoDominos.DataBind();

                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "none", "OpenModal('listaDominio') ;", true);

                }
                catch (Exception ex)
                {
                    Layers.Application.ExceptionUtility.LogException(ex, "Viendo listado de Dominos");
                }
            }
            else if (comando.Equals("Agregar"))
            {
                Id_tipo.Value = argumento.ToString();

                using (dbEntity = new SigacEntities())
                {
                    var titulo = dbEntity.SIEDU_TIPO_DOMINIO.Where(x => x.ID_TIPO_DOMINIO == argumento).Select(x => x.NOMBRE).First();
                    
                    LabelTituloDom.Text = $"Agregando Dominio al tipo '{titulo}'";
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "none", "OpenModal('newDomain') ;", true);
            }
        }
    }
}