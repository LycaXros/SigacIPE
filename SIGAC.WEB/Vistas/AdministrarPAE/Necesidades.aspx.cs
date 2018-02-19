using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGAC.Layers.Bussiness.Model;

namespace SIGAC.WEB.Vistas.AdministrarPAE
{
    public partial class Necesidades : System.Web.UI.Page
    {
        private Entidades _dbEntity = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDdl();
        }

        private void FillDdl()
        {
            using(_dbEntity = new Entidades())
            {
                var Years = _dbEntity.Sigac.SIEDU_DOMINIO
                    .Join(_dbEntity.Sigac.SIEDU_TIPO_DOMINIO,
                    dom => dom.ID_TIPO_DOMINIO, type => type.ID_TIPO_DOMINIO,
                    (dom, type) => new { dom, type })
                    .Where(x => x.type.NOMBRE.Equals("VIGENCIA"))
                    .OrderByDescending(x => x.dom.NOMBRE)
                    .Select(y => y.dom.NOMBRE)
                .ToList();



                if (!Years.Contains(DateTime.Now.Year.ToString()))
                {
                    Years.Insert(0, DateTime.Now.Year.ToString());
                }

                BuscarVigenciaDDL.DataSource = Years;
                BuscarVigenciaDDL.DataBind();

                var escuelas = _dbEntity.Siath.SIGAC_UNIDADES_DEPENDENCIA;


                BuscarEscuelaDDL.Items.Insert(0, new ListItem("Seleccione", "0"));

            }
        }

        protected void BuscarBTN_Click(object sender, EventArgs e)
        {
            string comando = (sender as IButtonControl).CommandName;

            switch (comando)
            {
                case "Buscar":

                    break;
                case "Agregar":
                case "Asociar":
                default:
                    return;
            }
        }
        
    }
}