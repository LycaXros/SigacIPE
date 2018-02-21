using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Bussiness.Model;
using System.Collections;
using SIGAC.Layers.Application;

namespace SIGAC.WEB.Vistas.AdministrarPAE
{
    public partial class Necesidades : System.Web.UI.Page
    {
        private Entidades _dbEntity = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            FillDdl();
        }

        private void FillDdl()
        {
            using (_dbEntity = new Entidades())
            {
                var Years = _dbEntity.Sigac.SIEDU_DOMINIO
                    .Join(_dbEntity.Sigac.SIEDU_TIPO_DOMINIO,
                    dom => dom.ID_TIPO_DOMINIO, type => type.ID_TIPO_DOMINIO,
                    (dom, type) => new { dom, type })
                    .Where(x => x.type.NOMBRE.Equals("VIGENCIA"))
                    .OrderByDescending(x => x.dom.NOMBRE)
                    .Select(y => y.dom.NOMBRE )
                .ToList();


                var actualYear = DateTime.Now.Year.ToString() ;
                if (!Years.Contains(actualYear)) 
                {
                    Years.Insert(0, actualYear);
                }
                
                var escuelas = _dbEntity.Siath.SIGAC_UNIDADES_DEPENDENCIA;
                BuscarVigenciaDDL.DataSource = Years;
                BuscarVigenciaDDL.DataBind();
                //BuscarVigenciaDDL.Items.Insert(0, new ListItem("Seleccione", "0"));
                

            }
        }

        protected void BuscarBTN_Click(object sender, EventArgs e)
        {
            string comando = (sender as IButtonControl).CommandName;
            string vigencia = BuscarVigenciaDDL.SelectedItem.Value;
            switch (comando)
            {
                case "Buscar":

                    break;
                case "Agregar":
                    AgregarVigenciaHidden.Value = vigencia;
                    PrepareModalAgregar();
                    break;
                case "Asociar":
                    AsociarVigenciaHidden.Value = vigencia;
                    PrepareModalAsociar();
                    break;
                default:
                    AgregarVigenciaHidden.Value = string.Empty;
                    AsociarVigenciaHidden.Value = string.Empty;
                    return;
            }
        }

        private void PrepareModalAsociar()
        {

        }

        private void PrepareModalAgregar()
        {
            using (_dbEntity = new Entidades())
            {
                var listaRegiones = _dbEntity.Siath.SIGAC_UNIDADES_DEPENDENCIA
                    .Select(x => x.REGI_CODIGO).Distinct().ToList()
                    .Join(_dbEntity.Siath.SIGAC_LUGARES_GEOGRAFICOS, region => region, lGeo => lGeo.CODIGO,
                    (region, lGeo) => new { Nombre = lGeo.CODI_PROVINCIA, Codigo = region })
                    .ToList();
                var listaUnidadDepende = _dbEntity.Siath.SIGAC_UNIDADES_DEPENDENCIA
                    .Select(x => new { Codigo = x.DEPE_CODIGO, Descripcion = x.DESCRIPCION_DEPENDENCIA }).Distinct().ToList();

                var listaNivelAcademico = _dbEntity.Siath.SIGAC_NIVELES_ACADEMICOS
                    .Select(x => new { ID = x.ID_NIVEL_ACADEMICO, Nombre = x.DESCRIPCION }).Distinct().ToList();
                PrepararDropDowns("AgregarRegionalDDL", listaRegiones, new KeyValuePair<string, string>("Codigo", "Nombre"));
                PrepararDropDowns("AgregarU_DependeDDL", listaUnidadDepende, new KeyValuePair<string, string>("ID", "Descripcion"));
                PrepararDropDowns("AgregarNivelDDL", listaNivelAcademico, new KeyValuePair<string, string>("ID", "Nombre"));
                OpenModal("modalAgregar");
            }
        }

        private void OpenModal(string modalId)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "none", $"OpenModal('{modalId.Trim().ToString()}');", true);
        }

        protected void AgregarNivelDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal value = decimal.Parse((sender as DropDownList).SelectedItem.Value);
            using (_dbEntity = new Entidades())
            {

                var listaProgramaAcademico = _dbEntity.Siath.SIGAC_CARRERAS
                                        .Where(x => x.ID_NIVEL_ACADEMICO.Equals(value))
                                        .Select(x => new { ID = x.ID_CARRERA, Nombre = x.DESCRIPCION }).Distinct().ToList();

                PrepararDropDowns("AgregarProgramaDDL", listaProgramaAcademico, new KeyValuePair<string, string>("ID", "Nombre"));
            }
        }

        private void PrepararDropDowns(string ddlID, IList data, KeyValuePair<string, string> campos)
        {
            try
            {
                var control = (Page.GetControl(ddlID) as DropDownList);
                if (control != null)
                {
                    control.DataTextField = campos.Value;
                    control.DataValueField = campos.Key;
                    control.Enabled = true;
                    control.DataSource = data;
                    control.DataBind();
                    control.Items.Insert(0, new ListItem("Seleccione", "0"));
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Preparacion de Dropdowns");
            }
        }

        protected void AgregarRegionalDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal value = decimal.Parse((sender as DropDownList).SelectedItem.Value);
            using (_dbEntity = new Entidades())
            {
                var listaUnidadFisica = _dbEntity.Siath.SIGAC_UNIDADES_DEPENDENCIA
                    .Where(x => x.REGI_CODIGO.Equals(value))
                    .Select(x => x.SIGLA_FISICA).Distinct().ToList();
                
                PrepararDropDowns("AgregarU_FisicaDDL", listaUnidadFisica, new KeyValuePair<string, string>("ID", "Nombre"));
            }
        }
    }
}